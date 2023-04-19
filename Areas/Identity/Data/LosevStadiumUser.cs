using Microsoft.AspNetCore.Identity;

namespace Kursovaya.Areas.Identity.Data
{
    public class LosevStadiumUser : IdentityUser

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
