﻿// <auto-generated />
using ChopinApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChopinApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChopinApi.Models.Entities.Composition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DurationInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPosthumous")
                        .HasColumnType("bit");

                    b.Property<int>("KeySignatureId")
                        .HasColumnType("int");

                    b.Property<int?>("MainOpusNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SubNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("YearOfComposition")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("KeySignatureId");

                    b.ToTable("Compositions");
                });

            modelBuilder.Entity("ChopinApi.Models.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ballade"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Etude"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Impromptu"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mazurka"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Nocturne"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Polonaise"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Prelude"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Rondo"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Scherzo"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Sonata"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Variation"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Waltz"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Concerto"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Miscellaneous"
                        });
                });

            modelBuilder.Entity("ChopinApi.Models.Entities.KeySignature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaseNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishNotation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GermanNotation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SymbolicNotation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KeySignatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseNote = "C",
                            EnglishNotation = "C major",
                            GermanNotation = "C-dur",
                            KeyType = "Major",
                            SymbolicNotation = "C"
                        },
                        new
                        {
                            Id = 2,
                            BaseNote = "G",
                            EnglishNotation = "G major",
                            GermanNotation = "G-dur",
                            KeyType = "Major",
                            SymbolicNotation = "G"
                        },
                        new
                        {
                            Id = 3,
                            BaseNote = "D",
                            EnglishNotation = "D major",
                            GermanNotation = "D-dur",
                            KeyType = "Major",
                            SymbolicNotation = "D"
                        },
                        new
                        {
                            Id = 4,
                            BaseNote = "A",
                            EnglishNotation = "A major",
                            GermanNotation = "A-dur",
                            KeyType = "Major",
                            SymbolicNotation = "A"
                        },
                        new
                        {
                            Id = 5,
                            BaseNote = "E",
                            EnglishNotation = "E major",
                            GermanNotation = "E-dur",
                            KeyType = "Major",
                            SymbolicNotation = "E"
                        },
                        new
                        {
                            Id = 6,
                            BaseNote = "B",
                            EnglishNotation = "B major",
                            GermanNotation = "H-dur",
                            KeyType = "Major",
                            SymbolicNotation = "B"
                        },
                        new
                        {
                            Id = 7,
                            BaseNote = "F#",
                            EnglishNotation = "F sharp major",
                            GermanNotation = "Fis-dur",
                            KeyType = "Major",
                            SymbolicNotation = "F#"
                        },
                        new
                        {
                            Id = 8,
                            BaseNote = "C#",
                            EnglishNotation = "C sharp major",
                            GermanNotation = "Cis-dur",
                            KeyType = "Major",
                            SymbolicNotation = "C#"
                        },
                        new
                        {
                            Id = 9,
                            BaseNote = "F",
                            EnglishNotation = "F major",
                            GermanNotation = "F-dur",
                            KeyType = "Major",
                            SymbolicNotation = "F"
                        },
                        new
                        {
                            Id = 10,
                            BaseNote = "B♭",
                            EnglishNotation = "B flat major",
                            GermanNotation = "B-dur",
                            KeyType = "Major",
                            SymbolicNotation = "B♭"
                        },
                        new
                        {
                            Id = 11,
                            BaseNote = "E♭",
                            EnglishNotation = "E flat major",
                            GermanNotation = "Es-dur",
                            KeyType = "Major",
                            SymbolicNotation = "E♭"
                        },
                        new
                        {
                            Id = 12,
                            BaseNote = "A♭",
                            EnglishNotation = "A flat major",
                            GermanNotation = "As-dur",
                            KeyType = "Major",
                            SymbolicNotation = "A♭"
                        },
                        new
                        {
                            Id = 13,
                            BaseNote = "D♭",
                            EnglishNotation = "D flat major",
                            GermanNotation = "Des-dur",
                            KeyType = "Major",
                            SymbolicNotation = "D♭"
                        },
                        new
                        {
                            Id = 14,
                            BaseNote = "G♭",
                            EnglishNotation = "G flat major",
                            GermanNotation = "Ges-dur",
                            KeyType = "Major",
                            SymbolicNotation = "G♭"
                        },
                        new
                        {
                            Id = 15,
                            BaseNote = "C♭",
                            EnglishNotation = "C flat major",
                            GermanNotation = "Ces-dur",
                            KeyType = "Major",
                            SymbolicNotation = "C♭"
                        },
                        new
                        {
                            Id = 16,
                            BaseNote = "A",
                            EnglishNotation = "A minor",
                            GermanNotation = "a-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "a"
                        },
                        new
                        {
                            Id = 17,
                            BaseNote = "E",
                            EnglishNotation = "E minor",
                            GermanNotation = "e-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "e"
                        },
                        new
                        {
                            Id = 18,
                            BaseNote = "B",
                            EnglishNotation = "B minor",
                            GermanNotation = "h-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "b"
                        },
                        new
                        {
                            Id = 19,
                            BaseNote = "F#",
                            EnglishNotation = "F sharp minor",
                            GermanNotation = "fis-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "f#"
                        },
                        new
                        {
                            Id = 20,
                            BaseNote = "C#",
                            EnglishNotation = "C sharp minor",
                            GermanNotation = "cis-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "c#"
                        },
                        new
                        {
                            Id = 21,
                            BaseNote = "G#",
                            EnglishNotation = "G sharp minor",
                            GermanNotation = "gis-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "g#"
                        },
                        new
                        {
                            Id = 22,
                            BaseNote = "D#",
                            EnglishNotation = "D sharp minor",
                            GermanNotation = "dis-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "d#"
                        },
                        new
                        {
                            Id = 23,
                            BaseNote = "B♭",
                            EnglishNotation = "B flat minor",
                            GermanNotation = "b-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "b♭"
                        },
                        new
                        {
                            Id = 24,
                            BaseNote = "E♭",
                            EnglishNotation = "E flat minor",
                            GermanNotation = "es-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "e♭"
                        },
                        new
                        {
                            Id = 25,
                            BaseNote = "A♭",
                            EnglishNotation = "A flat minor",
                            GermanNotation = "as-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "a♭"
                        },
                        new
                        {
                            Id = 26,
                            BaseNote = "D♭",
                            EnglishNotation = "D flat minor",
                            GermanNotation = "des-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "d♭"
                        },
                        new
                        {
                            Id = 27,
                            BaseNote = "G♭",
                            EnglishNotation = "G flat minor",
                            GermanNotation = "ges-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "g♭"
                        },
                        new
                        {
                            Id = 28,
                            BaseNote = "C",
                            EnglishNotation = "C minor",
                            GermanNotation = "c-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "c"
                        },
                        new
                        {
                            Id = 29,
                            BaseNote = "F",
                            EnglishNotation = "F minor",
                            GermanNotation = "f-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "f"
                        },
                        new
                        {
                            Id = 30,
                            BaseNote = "G",
                            EnglishNotation = "G minor",
                            GermanNotation = "g-moll",
                            KeyType = "Minor",
                            SymbolicNotation = "g"
                        });
                });

            modelBuilder.Entity("ChopinApi.Models.Entities.Composition", b =>
                {
                    b.HasOne("ChopinApi.Models.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChopinApi.Models.Entities.KeySignature", "KeySignature")
                        .WithMany()
                        .HasForeignKey("KeySignatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("KeySignature");
                });
#pragma warning restore 612, 618
        }
    }
}
