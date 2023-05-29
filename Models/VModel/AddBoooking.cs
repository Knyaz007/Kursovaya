using Kursovaay.Models;

namespace Kursovaya.Models.VModel
{
    public class AddBoooking
    {
        public Booking Booking { get; set; }
        public Tour Tour { get; set; }
        public User User { get; set; }
        public Hotel Hotel { get; set; }
        public Flight Flight { get; set; }

        public List<Tour>  Tours { get; set; }
        public List<User>   Users { get; set; }
        public List<Hotel>   Hotels { get; set; }
        public List<Flight>   Flights { get; set; }

    }
}
