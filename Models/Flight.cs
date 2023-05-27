using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Flight
    {

        [Key]
        public int Flight_Id { get; set; } /*идентификатор*/
        public string FlightNumber { get; set; } /*номер рейса*/
        public string Departure { get; set; } /*место отправления*/
        public string Destination { get; set; } /*место назначения*/
        public DateTime DepartureDateTime { get; set; }  /*дата и время вылета*/
        public List<Comment>? Comments { get; set; } // Список комментариев к туру

        

    }
}
