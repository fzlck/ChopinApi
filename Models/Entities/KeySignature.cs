namespace ChopinApi.Models.Entities
{
    public class KeySignature
    {
        public int Id { get; set; }
        public required string EnglishNotation { get; set; }
        public string? GermanNotation { get; set; }
        public string? SymbolicNotation { get; set; }
        public required string KeyType {  get; set; }
        public required string BaseNote { get; set; }


    }
}
