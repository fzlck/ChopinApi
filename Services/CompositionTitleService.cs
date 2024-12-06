using System.Text;
using ChopinApi.DTOs;
using ChopinApi.Repositories;

namespace ChopinApi.Services
{
    public class CompositionTitleService
    {
        private readonly KeySignatureRepository keySignatureRepository;
        private readonly GenreRepository genreRepository;

        public CompositionTitleService(KeySignatureRepository keySignatureRepository, GenreRepository genreRepository)
        {
            this.keySignatureRepository = keySignatureRepository;
            this.genreRepository = genreRepository;
        }
        public async Task<string> GenerateTitle(CreateCompositionDto createCompositionDto)
        {
            var title = new StringBuilder();
            
            if (createCompositionDto == null)
            {
                throw new ArgumentNullException(nameof(createCompositionDto));
            }

            if (createCompositionDto.Title != null)
            {
                return createCompositionDto.Title;
            }

            if (createCompositionDto?.GenreId != null)
            {
                var genreName = await genreRepository.GetGenreNameById(createCompositionDto.GenreId);
                title.Append(genreName);
            }

            if (createCompositionDto?.KeySignatureId != null)
            {
                var keySignatureName = await keySignatureRepository.GetKeySignatureEnglishNotationByIdAsync(createCompositionDto.KeySignatureId);
                title.Append($" in {keySignatureName}, ");
            }


            if (createCompositionDto?.MainOpusNumber != null)
            {
                title.Append($"Op. {createCompositionDto.MainOpusNumber}");
                if (createCompositionDto.SubNumber != null)
                {
                    title.Append($" No. {createCompositionDto.SubNumber}");
                }
            }

            if (createCompositionDto?.IsPosthumous == true)
            {
                title.Append("Op. posth.");
            }


            return title.ToString();


        }
    }
}
