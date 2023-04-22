namespace Kursovaya.Models.ViewModels
{
    public class TeamDetailsViewModel
    {
        public Tours Tour { get; set; }
        public IEnumerable<Customers> Customers { get; set; }
    }
}
