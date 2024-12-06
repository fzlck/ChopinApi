using Microsoft.EntityFrameworkCore;
using ChopinApi.Data;

namespace ChopinApi.Repositories
{
    public class KeySignatureRepository
    {
        private readonly ApplicationDbContext dbContext;

        public KeySignatureRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetKeySignatureEnglishNotationByIdAsync(int id)
        {
            var keySignature = await dbContext.KeySignatures.FindAsync(id);

            if (keySignature == null)
            {
                throw new ArgumentException($"Key Signature with ID {id} not found");
            }
            return keySignature.EnglishNotation;
        }

        public async Task<bool> KeySignatureExists(int id)
        {
            return await dbContext.KeySignatures.AnyAsync(k => k.Id == id);
        }

    }
}
