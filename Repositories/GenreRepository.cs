using Microsoft.EntityFrameworkCore;
using ChopinApi.Data;

namespace ChopinApi.Repositories
{
    public class GenreRepository
    {
        private readonly ApplicationDbContext dbContext;

        public GenreRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetGenreNameById(int id)
        {
            var genre = await dbContext.Genres.FindAsync(id);
            if (genre == null)
            {
                throw new ArgumentException($"Genre with ID {id} not found");
            }
            return genre.Name;
        }

        public async Task<bool> GenreExists(int id)
        {
            return await dbContext.Genres.AnyAsync(g => g.Id == id);
        }
    
    }
}
