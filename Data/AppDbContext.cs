using ABDALLAH.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ABDALLAH.Data
{
    public class AppDbContext : IdentityDbContext<User>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<PRODUCT> PRODUCTS { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
