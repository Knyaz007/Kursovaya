using System.ComponentModel.DataAnnotations;
namespace Kursovaya.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public Customers? Customers { get; set; }

        [Required, Display(Name = "Дата оформления"), DataType(DataType.Date)]
        public DateTime DateCreate { get; set; }

        public Tours? Tours { get; set; }

        public ICollection<Customers>? Loggings { get; set; }
        //public Order()
        //{
        //    Tours = new List<Tours>();
        //}


    }
}
