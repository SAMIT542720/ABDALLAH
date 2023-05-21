using Microsoft.AspNetCore.Identity;

namespace Samit_For__Trading.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public int PhoneNumberRT { get; set; }
        public int PhoneNumberTG { get; set; }
    }
}
