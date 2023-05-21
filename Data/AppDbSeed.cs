using Microsoft.AspNetCore.Identity;
using Samit_For__Trading.Data.Static;
using Samit_For__Trading.Models;
using static Azure.Core.HttpHeader;

namespace Samit_For__Trading.Data
{
    public class AppDbSeed
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScop = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScop.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Product
                if (!context.PRODUCTS.Any())
                {
                    context.PRODUCTS.AddRange(new List<PRODUCT>()
                    {
                        new PRODUCT()
                        {
                            CostumerFullName="ADAM MAHAMAT AHMAT",
                            CotumerCity="ABESHE",
                            CostumerPhoneNumber=99285427,
                            PNumber=200,
                            NameFR="TOP MALT",
                            NameAR="أعلى الشعير",
                            Benefit=150,
                            Price=1860,
                            Description="TOP MALT",
                            Destination="ABESHE",
                            Date=DateTime.Now.AddDays(-30),
                            Payment=1290000,
                            ShippingPayment=1200,
                        },

                        new PRODUCT()
                        {
                            CostumerFullName="ABAKAR ADAM BARAKA",
                            CotumerCity="ABESHE",
                            CostumerPhoneNumber=99886258,
                            PNumber=180,
                            NameFR="TOP MALT",
                            NameAR="أعلى الشعير",
                            Benefit=150,
                            Price=1860,
                            Description="TOP MALT",
                            Destination="ABESHE",
                            Date=DateTime.Now.AddDays(-30),
                            Payment=1674000,
                            ShippingPayment=800,
                        },
                        new PRODUCT()
                        {
                            CostumerFullName="MAHAMAT ADAMM",
                            CotumerCity="ABESHE",
                            CostumerPhoneNumber=2743289,
                            PNumber=200,
                            NameFR="TOP MALT",
                            NameAR="أعلى الشعير",
                            Benefit=150,
                            Price=1860,
                            Description="TOP MALT",
                            Destination="ABESHE",
                            Date=DateTime.Now.AddDays(-30),
                            Payment=1290000,
                            ShippingPayment=1200,
                        },
                        new PRODUCT()
                        {
                            CostumerFullName="ADAM MAHAMAT AHMAT",
                            CotumerCity="ABESHE",
                            CostumerPhoneNumber=99282940,
                            PNumber=200,
                            NameFR="TOP MALT",
                            NameAR="أعلى الشعير",
                            Benefit=150,
                            Price=1860,
                            Description="TOP MALT",
                            Destination="ABESHE",
                            Date=DateTime.Now.AddDays(-30),
                            Payment=1290000,
                            ShippingPayment=1200,
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsers(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRole.ADMIN))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.ADMIN));
                if (!await roleManager.RoleExistsAsync(UserRole.USER))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.USER));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "hissensamit@trading.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        FullName = "HISSEN MAHAMAT SAMIT",
                        UserName = "HISSE_SAMIT",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        
                    };
                    await userManager.CreateAsync(newAdminUser, "Hissen@99");
                    await userManager.AddToRoleAsync(newAdminUser, UserRole.ADMIN);
                }
                string appUserEmail = "user@trading.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "User@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRole.USER);
                }
            }
        }
    }
}
