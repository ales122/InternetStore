using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class Series : Movie
    {
        public int AmountOfSeasons { get; set; }
    }
}
