using Kursovaya.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace Kursovaay.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Идентификатор бронирования ")]
        public int BookingId { get; set; } // Идентификатор бронирования
        [Display(Name = " Идентификатор тура ")]
        public int TourId { get; set; } // Идентификатор тура, на который произведено бронирование
        
        public Tour? Tour { get; set; } // Ссылка на объект тура
        [Display(Name = "ID Клиента ")]
        public int UserId { get; set; } // Идентификатор пользователя, совершившего бронирование
        
        public User? User { get; set; } // Ссылка на объект пользователя
        [Display(Name = "ID Авиарейса ")]
        public int FlightId { get; set; } // Идентификатор Авиарейса  , Накотором летим
       
        public Flight? Flight { get; set; } // Ссылка на объект пользователя
        [Display(Name = "ID Отеля ")]
        public int HotelId { get; set; } // Идентификатор Отеля  , Где будем жить
         
        public Hotel? Hotel { get; set; } // Ссылка на объект отель
        [Display(Name = " Количество участников")]
        public int ParticipantsCount { get; set; } // Количество участников
        [Display(Name = "Дата бронирования ")]
        public DateTime BookingDate { get; set; } // Дата бронирования
       
        [Display(Name = "Флаг, указывающий, подтверждено ли бронирование работником")]
        //public Employee? Employees { get; set; } // Ссылка на РАботника 
        public bool IsConfirmed { get; set; } // Флаг, указывающий, подтверждено ли бронирование работником 

    }
}
