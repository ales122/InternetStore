using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public List<Movie> LikedMovies { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Warning> Warnings { get; set; }
    }


}
