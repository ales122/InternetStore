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

        public User User { get; set; }

        public List<Like> Likes { get; set; }
    }
}
