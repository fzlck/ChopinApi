namespace ChopinApi.DTOs
{
    public class CreateCompositionDto
    {
        public required string Title { get; set; }
        public string? YearOfComposition { get; set; }
        public int? DurationInSeconds { get; set; }
        public int KeySignatureId { get; set; }
        public int GenreId { get; set; }
        public int? MainOpusNumber { get; set; }
        public int? SubNumber { get; set; }
        public bool? IsPosthumous { get; set; }


    }
}
