using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Tours
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "дата начала тура")]
        public string tour_start_date { get; set; }
        [Display(Name = "дата конца тура")]
        public string end_date_of_the_tour { get; set; }

        [Display(Name = "тип тура")]
        public string type_of_tour { get; set; }
        [Display(Name = "тип питания")]
        public string type_of_power_supply { get; set; }//тип питания;  отель
        [Display(Name = "отель")]
        public string hotel { get; set; }
        [Display(Name = "рейс вылета")]
        public string departure_flight { get; set; }
        [Display(Name = "рейс прилета")]
        public string arrival_flight { get; set; }
    }
}
