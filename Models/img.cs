using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class img
    {
        [Key]
        public int Img_id { get; set; }
        public string? Photo { get; set; }
    }
}
