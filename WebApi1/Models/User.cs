using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class User:IdentityUser
    {
       public int Year { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }

   
}
