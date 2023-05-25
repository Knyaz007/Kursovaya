namespace Kursovaay.Models
{
    public class Review // Обзор
    {
        public int ReviewId { get; set; } // Идентификатор отзыва
        public int TourId { get; set; } // Идентификатор тура, для которого оставлен отзыв
        public Tour? Tour { get; set; } // Ссылка на объект тура
        public int UserId { get; set; } // Идентификатор пользователя, оставившего отзыв
        public User? User { get; set; } // Ссылка на объект пользователя
        public string? Comment { get; set; } // Комментарий к отзыву
        public int Rating { get; set; } // Рейтинг тура, оставленный пользователем
    }
    







}
