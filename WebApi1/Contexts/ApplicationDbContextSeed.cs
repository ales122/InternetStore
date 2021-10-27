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
        public static async Task SeedEssentialAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,UsersContext context)
        {
            if (!roleManager.Roles.Any())
            {
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.user.ToString()));
            var default_user = new User { Email = Authorization.default_email, UserName = Authorization.default_email, Year = Authorization.default_year };

            await userManager.CreateAsync(default_user);
            await userManager.AddToRoleAsync(default_user, Authorization.Roles.user.ToString());
            }
            if (!context.Genres.Any())
            {


                Genre genre = new Genre() { Name = "action" };
                Genre genre1 = new Genre() { Name = "detective" };
                Genre genre2 = new Genre() { Name = "romantic" };
                context.Genres.AddRange(genre, genre1, genre2);

                Country country = new Country() { Name = "USA" };
                Country country1 = new Country() { Name = "Canada" };
                Country country2 = new Country() { Name = "Germany" };
                context.Countries.AddRange(country, country1, country2);

                Movie movie = new Movie() { Name = "Knives out", Year = 2015, ShortDescription = "aaaa", FullDescription = "aaa" };
                Movie movie1 = new Movie() { Name = "Knives out", Year = 2015, ShortDescription = "aaaa", FullDescription = "aaa" };
                context.Movies.AddRange(movie, movie1);



                movie.Countries.Add(country1);
                movie.Countries.Add(country2);

                movie.Genres.Add(genre1);
                movie.Genres.Add(genre);


                movie1.Countries.Add(country1);
                movie1.Countries.Add(country2);

                movie1.Genres.Add(genre1);
                movie1.Genres.Add(genre);


                context.SaveChanges();
            }
        }
    }
}
