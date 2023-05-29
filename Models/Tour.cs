using Kursovaya.Models;
using System.ComponentModel.DataAnnotations;

namespace Kursovaay.Models
{
    public class Tour
    {
        [Display(Name = " Идентификатор тура ")]
        [Key]
        public int TourId { get; set; } // Идентификатор тура
        [Display(Name = " Название тура ")]
        public string Name { get; set; } // Название тура
        [Display(Name = "Описание тура")]
        public string Description { get; set; } // Описание тура
        [Display(Name = "Стоимость тура")]
        public double Price { get; set; } // Стоимость тура
        [Display(Name = " Дата начала тура")]
        public DateTime StartDate { get; set; } // Дата начала тура
        [Display(Name = " Дата окончания тура")]
        public DateTime EndDate { get; set; } // Дата окончания тура
        [Display(Name = "доступных мест")]
        public int AvailableSpots { get; set; } // Количество доступных мест для тура
        [Display(Name = " Идентификатор тура ")]
        public List<Comment>? Comments { get; set; } // Список комментариев к Тура
        public void AddComment(Comment comment)
        {
            if (Comments == null)
                Comments = new List<Comment>();

            Comments.Add(comment);
        }

    }
}
