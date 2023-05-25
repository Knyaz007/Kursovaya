namespace Kursovaay.Models
{
    public class Booking
    {
        public int BookingId { get; set; } // Идентификатор бронирования
        public int TourId { get; set; } // Идентификатор тура, на который произведено бронирование
        public Tour? Tour { get; set; } // Ссылка на объект тура
        public int UserId { get; set; } // Идентификатор пользователя, совершившего бронирование
        public User? User { get; set; } // Ссылка на объект пользователя
        public int ParticipantsCount { get; set; } // Количество участников
        public DateTime BookingDate { get; set; } // Дата бронирования
        public bool IsConfirmed { get; set; } // Флаг, указывающий, подтверждено ли бронирование

    }
}
