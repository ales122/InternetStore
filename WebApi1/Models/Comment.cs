using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }

        public virtual User User { get; set; }

        public virtual List<Like> Likes { get; set; } = new List<Like>();
        public virtual Movie Movie { get; set; }
    }
}
