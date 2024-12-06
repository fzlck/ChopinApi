using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using ChopinApi.Data;
using ChopinApi.Models.Entities;
using ChopinApi.Services;
using ChopinApi.DTOs;

namespace ChopinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly CompositionTitleService compositionTitleService;
        private readonly CompositionValidationService compositionValidationService;

        public CompositionsController(
            ApplicationDbContext dbContext,
            CompositionTitleService compositionTitleService,
            CompositionValidationService compositionValidationService)
        {
            this.dbContext = dbContext;
            this.compositionTitleService = compositionTitleService;
            this.compositionValidationService = compositionValidationService;
        }

        [HttpGet]
        public IActionResult GetAllCompositions(
            [FromQuery] string? title,
            [FromQuery] string? titleMatchType,
            [FromQuery] string? yearOfComposition,
            [FromQuery] int? keySignatureId,
            [FromQuery] int? genreId,
            [FromQuery] int? durationInSeconds,
            [FromQuery] int? mainOpusNumber,
            [FromQuery] int? subNumber,
            [FromQuery] bool? isPosthumous,
            [FromQuery] string? expand)
        {
            var query = dbContext.Compositions.AsQueryable();

            if (!String.IsNullOrEmpty(title))
            {
                string matchType = titleMatchType ?? "equals";

                if (string.Equals(titleMatchType, "contains", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(c => c.Title.ToLower().Contains(title.ToLower()));
                }
                else
                {
                    query = query.Where(c => c.Title == title);
                }
            }

            if (!String.IsNullOrEmpty(yearOfComposition))
                query = query.Where(c => c.YearOfComposition == yearOfComposition);

            if (keySignatureId.HasValue)
                query = query.Where(c => c.KeySignatureId == keySignatureId);

            if (genreId.HasValue)
                query = query.Where(c => c.GenreId == genreId);

            if (durationInSeconds.HasValue)
                query = query.Where(c => c.DurationInSeconds == durationInSeconds);

            if (mainOpusNumber.HasValue)
                query = query.Where(c => c.MainOpusNumber == mainOpusNumber);

            if (subNumber.HasValue)
                query = query.Where(c => c.SubNumber == subNumber);

            if (isPosthumous.HasValue)
                query = query.Where(c => c.IsPosthumous == isPosthumous);
       

            if(!string.IsNullOrEmpty(expand))
            {
                var expands = expand.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if  (expands.Contains("keySignature"))
                    query = query.Include(c => c.KeySignature);
                if (expands.Contains("genre"))
                    query = query.Include(c => c.Genre);
  
            }

            return Ok(query.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> CreateComposition(CreateCompositionDto createCompositionDto)
        {
            var generatedTitle = await compositionTitleService.GenerateTitle(createCompositionDto);

            await compositionValidationService.ValidateGenre(createCompositionDto.GenreId);
            await compositionValidationService.ValidateKeySignature(createCompositionDto.KeySignatureId);

            var composition = new Composition()
            {
                Title = generatedTitle,
                YearOfComposition = createCompositionDto.YearOfComposition,
                DurationInSeconds = createCompositionDto.DurationInSeconds,
                GenreId = createCompositionDto.GenreId,
                KeySignatureId = createCompositionDto.KeySignatureId,
                MainOpusNumber = createCompositionDto.MainOpusNumber,
                SubNumber = createCompositionDto.SubNumber,
                IsPosthumous = createCompositionDto.IsPosthumous ?? false,
            };

            await dbContext.AddAsync(composition);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComposition), new {id = composition.Id}, composition);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComposition(int id)
        {
            var composition = await dbContext.Compositions.FindAsync(id);
            if (composition is null)
            {
                return NotFound();
            }

            return Ok(composition);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComposition(int id)
        {
            var composition = await dbContext.Compositions.FindAsync(id);
            if (composition is null)
            {
                return NotFound();
            }
            dbContext.Compositions.Remove(composition);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComposition(int id, [FromBody] UpdateCompositionDto updateCompositionDto)
        {
            var composition = await dbContext.Compositions.FindAsync(id);
            if (composition is null)
            {
                return NotFound();
            }

            await compositionValidationService.ValidateGenre(updateCompositionDto.GenreId);
            await compositionValidationService.ValidateKeySignature(updateCompositionDto.KeySignatureId);

            composition.Title = updateCompositionDto.Title ?? "";
            composition.YearOfComposition = updateCompositionDto.YearOfComposition;
            composition.DurationInSeconds = updateCompositionDto.DurationInSeconds;
            composition.GenreId = updateCompositionDto.GenreId ?? composition.GenreId;
            composition.KeySignatureId = updateCompositionDto.KeySignatureId ?? composition.KeySignatureId;
            composition.MainOpusNumber = updateCompositionDto.MainOpusNumber;
            composition.SubNumber = updateCompositionDto.SubNumber;
            composition.IsPosthumous = updateCompositionDto.IsPosthumous ?? false;

            await dbContext.SaveChangesAsync();

            return Ok(composition);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> PatchComposition(int id, [FromBody] UpdateCompositionDto updateCompositionDto)
        {
            var composition = await dbContext.Compositions.FindAsync(id);
            if (composition is null)
            {
                return NotFound();
            }

            if (updateCompositionDto.Title is not null)
                composition.Title = updateCompositionDto.Title;

            if (updateCompositionDto.YearOfComposition is not null)
                composition.YearOfComposition = updateCompositionDto.YearOfComposition;

            if (updateCompositionDto.DurationInSeconds is not null)
                composition.DurationInSeconds = updateCompositionDto.DurationInSeconds;

            if (updateCompositionDto.GenreId.HasValue)
            {
                await compositionValidationService.ValidateGenre(updateCompositionDto.GenreId);
                composition.GenreId = updateCompositionDto.GenreId.Value;
            }

            if (updateCompositionDto.KeySignatureId.HasValue)
            {
                await compositionValidationService.ValidateKeySignature(updateCompositionDto.KeySignatureId);
                composition.KeySignatureId = updateCompositionDto.KeySignatureId.Value;
            }

            if (updateCompositionDto.MainOpusNumber.HasValue)
                composition.MainOpusNumber = updateCompositionDto.MainOpusNumber.Value;

            if (updateCompositionDto.SubNumber.HasValue)
                composition.SubNumber = updateCompositionDto.SubNumber.Value;

            if (updateCompositionDto.IsPosthumous is not null)
                composition.IsPosthumous = updateCompositionDto.IsPosthumous.Value;

            await dbContext.SaveChangesAsync();

            return Ok(composition);
        }

    }
}
