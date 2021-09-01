using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class AccessModel
    {
        public string JWTtoken { get; set; }
        public RefreshToken  RefreshToken { get; set; }
        public string message { get; set; }
    }
}
