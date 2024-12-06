using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChopinApi.Models.Entities
{
    public class Composition
    {
  
        public int Id { get; set; }
        [StringLength(200)]
        public required string Title { get; set; }
        public string? YearOfComposition { get; set; }
        public int? DurationInSeconds {  get; set; }

        [ForeignKey(nameof(KeySignature))]
        public int KeySignatureId { get; set; }
        public KeySignature KeySignature { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int? MainOpusNumber { get; set; }
        public int? SubNumber { get; set; }
        public bool IsPosthumous { get; set; } = false;



    }
}
