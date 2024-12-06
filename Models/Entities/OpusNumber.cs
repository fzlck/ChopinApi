using System.ComponentModel.DataAnnotations;

namespace ChopinApi.Models.Entities
{
    public class OpusNumber
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string? MainOpusNumber { get; set; }
        [StringLength(10)]
        public string? SubNumber { get; set; }
        public bool IsPosthumous { get; set; } = false;



    }
}
