using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChopinApi.Data;

namespace ChopinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public GenresController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetGenres() 
        {
            return Ok(dbContext.Genres.ToList());
        }
    }
}
