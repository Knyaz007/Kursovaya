using Kursovaay.Models;
using Kursovaya.Models.VModel;
using Microsoft.EntityFrameworkCore;
namespace Kursovaya.Models
{
    public class TravAgenDBContext : DbContext
    {
        public TravAgenDBContext(DbContextOptions<TravAgenDBContext> options) :
   base(options)
        {
        }


        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }         
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<img> img { get; set; }



    }
}

