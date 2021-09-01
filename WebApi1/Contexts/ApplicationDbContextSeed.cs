using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Constants;
using WebApi1.Models;

namespace WebApi1.Contexts
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.User.ToString()));
            var default_user = new User { Email = Authorization.default_email, UserName = Authorization.default_email, Year = Authorization.default_year };

            await userManager.CreateAsync(default_user);
            await userManager.AddToRoleAsync(default_user, Authorization.Roles.User.ToString());
        }
    }
}
