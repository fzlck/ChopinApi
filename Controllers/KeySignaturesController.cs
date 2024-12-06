using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChopinApi.Data;

namespace ChopinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeySignaturesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public KeySignaturesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetKeySignatures()
        {
            return Ok(dbContext.KeySignatures.ToList());
        }
    }
}
