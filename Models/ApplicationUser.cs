using Microsoft.AspNetCore.Identity;

namespace CharityConnect.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Donation>? Donations { get; set; }
    }
}
