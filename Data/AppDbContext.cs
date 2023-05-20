using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Samit_For__Trading.Models;

namespace Samit_For__Trading.Data
{
    public class AppDbContext: IdentityDbContext<User>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<PRODUCT> PRODUCTS { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
