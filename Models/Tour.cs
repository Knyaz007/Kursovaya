using Kursovaya.Models;
using System.ComponentModel.DataAnnotations;

namespace Kursovaay.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; } // Идентификатор тура
        public string Name { get; set; } // Название тура
        public string Description { get; set; } // Описание тура
        public double Price { get; set; } // Стоимость тура
        public DateTime StartDate { get; set; } // Дата начала тура
        public DateTime EndDate { get; set; } // Дата окончания тура
        public int AvailableSpots { get; set; } // Количество доступных мест для тура

        public List<Comment> Comments { get; set; } // Список комментариев к Тура

    }
}
