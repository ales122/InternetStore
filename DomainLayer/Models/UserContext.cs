using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class UsersContext:IdentityDbContext<User>
    {
        public DbSet<Movie> Movies { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
