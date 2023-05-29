using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Models
{
    public class Hotel
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; } /*идентификатор*/
        [Display(Name = "Название")]
        public string Name { get; set; } /*название*/
        [Display(Name = "Адресс")]
        public string Address { get; set; } /*адресс*/
        //public int Rating { get; set; } рейтинг
        [Display(Name = "Кол-во свободных комнат")]
        public int AvailableRooms { get; set; } /* количество свободных комнат*/
        [Display(Name = "Комментарии")]
        public List<Comment>? Comments { get; set; } // Список комментариев к Отелю


    }
}
