using Microsoft.AspNetCore.Identity;

namespace ABDALLAH.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
