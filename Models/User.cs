using Microsoft.AspNetCore.Identity;

namespace Samit_For__Trading.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
