using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Customers
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Фамилия")]
        public string surname { get; set; }
        [Display(Name = "Имя")]
        public string name { get; set; }
        [Display(Name = "отчество")]
        public string Otchestvo { get; set; }
        [Display(Name = "Адресс")]
        public string address { get; set; }
        [Display(Name = "Телефон")]
        public string telephone { get; set; }
    }
}
