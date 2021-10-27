using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
