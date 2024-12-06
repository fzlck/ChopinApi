using ChopinApi.Repositories;

namespace ChopinApi.Services
{
    public class CompositionValidationService
    {
        private readonly GenreRepository genreRepository;
        private readonly KeySignatureRepository keySignatureRepository;

        public CompositionValidationService(GenreRepository genreRepository, KeySignatureRepository keySignatureRepository)
        {
            this.genreRepository = genreRepository;
            this.keySignatureRepository = keySignatureRepository;
        }

        public async Task ValidateKeySignature(int? keySignatureId)
        {
            if (keySignatureId.HasValue && !await keySignatureRepository.KeySignatureExists(keySignatureId.Value))
            {
                throw new ArgumentException($"Key Signature with ID {keySignatureId} does not exist");
            }
        }

        public async Task ValidateGenre(int? genreId)
        {
            if (genreId.HasValue && !await genreRepository.GenreExists(genreId.Value))
            {
                throw new ArgumentException($"Genre with ID {genreId} does not exist.");
            }
        }

        
    }
}
