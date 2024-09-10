using Microsoft.AspNetCore.Identity;

namespace Dern_Support_System.Models
{
    public class AppUser : IdentityUser
    {
        public Customer Customer { get; set; }
    }
}
