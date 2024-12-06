using Microsoft.EntityFrameworkCore;
using ChopinApi.Models.Entities;

namespace ChopinApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<KeySignature> KeySignatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Genres
            var genres = new[]
            {
                "Ballade", "Etude", "Impromptu", "Mazurka", "Nocturne",
                "Polonaise", "Prelude", "Rondo", "Scherzo", "Sonata",
                "Variation", "Waltz", "Concerto", "Miscellaneous"
            };
            var genreList = genres.Select((name, index) => new Genre()
            {
                Id = ++index,
                Name = name,
            }).ToArray();
            modelBuilder.Entity<Genre>().HasData(genreList);

            // Seed KeySignatures
            modelBuilder.Entity<KeySignature>().HasData(
                // Major keys
                new KeySignature { Id = 1, EnglishNotation = "C major", GermanNotation = "C-dur", SymbolicNotation = "C", KeyType = "Major", BaseNote = "C" },
                new KeySignature { Id = 2, EnglishNotation = "G major", GermanNotation = "G-dur", SymbolicNotation = "G", KeyType = "Major", BaseNote = "G" },
                new KeySignature { Id = 3, EnglishNotation = "D major", GermanNotation = "D-dur", SymbolicNotation = "D", KeyType = "Major", BaseNote = "D" },
                new KeySignature { Id = 4, EnglishNotation = "A major", GermanNotation = "A-dur", SymbolicNotation = "A", KeyType = "Major", BaseNote = "A" },
                new KeySignature { Id = 5, EnglishNotation = "E major", GermanNotation = "E-dur", SymbolicNotation = "E", KeyType = "Major", BaseNote = "E" },
                new KeySignature { Id = 6, EnglishNotation = "B major", GermanNotation = "H-dur", SymbolicNotation = "B", KeyType = "Major", BaseNote = "B" },
                new KeySignature { Id = 7, EnglishNotation = "F sharp major", GermanNotation = "Fis-dur", SymbolicNotation = "F#", KeyType = "Major", BaseNote = "F#" },
                new KeySignature { Id = 8, EnglishNotation = "C sharp major", GermanNotation = "Cis-dur", SymbolicNotation = "C#", KeyType = "Major", BaseNote = "C#" },
                new KeySignature { Id = 9, EnglishNotation = "F major", GermanNotation = "F-dur", SymbolicNotation = "F", KeyType = "Major", BaseNote = "F" },
                new KeySignature { Id = 10, EnglishNotation = "B flat major", GermanNotation = "B-dur", SymbolicNotation = "B♭", KeyType = "Major", BaseNote = "B♭" },
                new KeySignature { Id = 11, EnglishNotation = "E flat major", GermanNotation = "Es-dur", SymbolicNotation = "E♭", KeyType = "Major", BaseNote = "E♭" },
                new KeySignature { Id = 12, EnglishNotation = "A flat major", GermanNotation = "As-dur", SymbolicNotation = "A♭", KeyType = "Major", BaseNote = "A♭" },
                new KeySignature { Id = 13, EnglishNotation = "D flat major", GermanNotation = "Des-dur", SymbolicNotation = "D♭", KeyType = "Major", BaseNote = "D♭" },
                new KeySignature { Id = 14, EnglishNotation = "G flat major", GermanNotation = "Ges-dur", SymbolicNotation = "G♭", KeyType = "Major", BaseNote = "G♭" },
                new KeySignature { Id = 15, EnglishNotation = "C flat major", GermanNotation = "Ces-dur", SymbolicNotation = "C♭", KeyType = "Major", BaseNote = "C♭" },

                // Minor keys
                new KeySignature { Id = 16, EnglishNotation = "A minor", GermanNotation = "a-moll", SymbolicNotation = "a", KeyType = "Minor", BaseNote = "A" },
                new KeySignature { Id = 17, EnglishNotation = "E minor", GermanNotation = "e-moll", SymbolicNotation = "e", KeyType = "Minor", BaseNote = "E" },
                new KeySignature { Id = 18, EnglishNotation = "B minor", GermanNotation = "h-moll", SymbolicNotation = "b", KeyType = "Minor", BaseNote = "B" },
                new KeySignature { Id = 19, EnglishNotation = "F sharp minor", GermanNotation = "fis-moll", SymbolicNotation = "f#", KeyType = "Minor", BaseNote = "F#" },
                new KeySignature { Id = 20, EnglishNotation = "C sharp minor", GermanNotation = "cis-moll", SymbolicNotation = "c#", KeyType = "Minor", BaseNote = "C#" },
                new KeySignature { Id = 21, EnglishNotation = "G sharp minor", GermanNotation = "gis-moll", SymbolicNotation = "g#", KeyType = "Minor", BaseNote = "G#" },
                new KeySignature { Id = 22, EnglishNotation = "D sharp minor", GermanNotation = "dis-moll", SymbolicNotation = "d#", KeyType = "Minor", BaseNote = "D#" },
                new KeySignature { Id = 23, EnglishNotation = "B flat minor", GermanNotation = "b-moll", SymbolicNotation = "b♭", KeyType = "Minor", BaseNote = "B♭" },
                new KeySignature { Id = 24, EnglishNotation = "E flat minor", GermanNotation = "es-moll", SymbolicNotation = "e♭", KeyType = "Minor", BaseNote = "E♭" },
                new KeySignature { Id = 25, EnglishNotation = "A flat minor", GermanNotation = "as-moll", SymbolicNotation = "a♭", KeyType = "Minor", BaseNote = "A♭" },
                new KeySignature { Id = 26, EnglishNotation = "D flat minor", GermanNotation = "des-moll", SymbolicNotation = "d♭", KeyType = "Minor", BaseNote = "D♭" },
                new KeySignature { Id = 27, EnglishNotation = "G flat minor", GermanNotation = "ges-moll", SymbolicNotation = "g♭", KeyType = "Minor", BaseNote = "G♭" },
                new KeySignature { Id = 28, EnglishNotation = "C minor", GermanNotation = "c-moll", SymbolicNotation = "c", KeyType = "Minor", BaseNote = "C" },
                new KeySignature { Id = 29, EnglishNotation = "F minor", GermanNotation = "f-moll", SymbolicNotation = "f", KeyType = "Minor", BaseNote = "F" },
                new KeySignature { Id = 30, EnglishNotation = "G minor", GermanNotation = "g-moll", SymbolicNotation = "g", KeyType = "Minor", BaseNote = "G" }
            );

            base.OnModelCreating(modelBuilder);
        }


    }
}
