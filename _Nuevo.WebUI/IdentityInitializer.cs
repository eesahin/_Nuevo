using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Nuevo.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace _Nuevo.WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Administrator");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Administrator" });
            }
            var adminUser = userManager.FindByNameAsync("eesahin");
            if (adminUser.Result == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Emre",
                    Surname = "Şahin",
                    UserName = "eesahin",
                    Email = "emre@emreshn.com"
                };
                await userManager.CreateAsync(user, "1");
                IEnumerable<string> data = new List<string>
                {
                    "Administrator"
                };
                await userManager.AddToRolesAsync(user, data);
            }
        }
    }
}
