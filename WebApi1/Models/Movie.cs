using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        public virtual List<Like> Likes { get; set; } = new List<Like>();
        public virtual List<Genre> Genres { get; set; } = new List<Genre>();

        public virtual List<Country> Countries { get; set; } = new List<Country>();
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
