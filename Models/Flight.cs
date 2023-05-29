using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Flight
    {
        [Display(Name = "ID")]
        [Key]
        public int Flight_Id { get; set; } /*идентификатор*/
        [Display(Name = "Номер рейса")]
        public string FlightNumber { get; set; } /*номер рейса*/
        [Display(Name = "Место отправление")]
        public string Departure { get; set; } /*место отправления*/
        [Display(Name = "Место назначение")]
        public string Destination { get; set; } /*место назначения*/
        [Display(Name = "Дата вылета ")]
        public DateTime DepartureDateTime { get; set; }  /*дата и время вылета*/
        //[Display(Name = "Осталось мест")]
        //public int AvailableRooms { get; set; }  /*Осталось мест*/
        [Display(Name = "Комментарий")]
        public List<Comment>? Comments { get; set; } // Список комментариев к туру
    }
}
