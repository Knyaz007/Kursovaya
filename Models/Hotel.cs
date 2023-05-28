using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; } /*идентификатор*/
        public string Name { get; set; } /*название*/
        public string Address { get; set; } /*адресс*/
        //public int Rating { get; set; } рейтинг
        public int AvailableRooms { get; set; } /* количество свободных комнат*/

        public List<Comment>? Comments { get; set; } // Список комментариев к Отелю


    }
}
