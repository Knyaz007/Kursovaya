using Kursovaya.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace Kursovaay.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; } // Идентификатор бронирования
        public int TourId { get; set; } // Идентификатор тура, на который произведено бронирование
        public Tour? Tour { get; set; } // Ссылка на объект тура
        public int UserId { get; set; } // Идентификатор пользователя, совершившего бронирование
        public User? User { get; set; } // Ссылка на объект пользователя

        public int FlightId { get; set; } // Идентификатор Авиарейса  , Накотором летим
        public Flight? Flight { get; set; } // Ссылка на объект пользователя

        public int HotelId { get; set; } // Идентификатор Отеля  , Где будем жить
        public Hotel? Hotel { get; set; } // Ссылка на объект отель

        public int ParticipantsCount { get; set; } // Количество участников
        public DateTime BookingDate { get; set; } // Дата бронирования

        //public Employee? Employees { get; set; } // Ссылка на РАботника 
        public bool IsConfirmed { get; set; } // Флаг, указывающий, подтверждено ли бронирование работником 

    }
}
