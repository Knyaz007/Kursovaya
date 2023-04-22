using Microsoft.EntityFrameworkCore;
namespace Kursovaya.Models
{
    public class TravAgenDBContext : DbContext
    {
        public TravAgenDBContext(DbContextOptions<TravAgenDBContext> options) :
   base(options)
        {
        }
        public DbSet<Tours> Tours { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Order> Order { get; set; }

    }
}

