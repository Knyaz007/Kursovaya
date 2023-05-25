using Kursovaay.Models;
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
        public DbSet<User> User { get; set; }
         
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Review> Review { get; set; }

    }
}

