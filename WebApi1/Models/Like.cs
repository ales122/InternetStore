using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class Like
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
