using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class Warning
    {
        public Guid Id { get; set; }
        public string WarningReason { get; set; }
        public DateTime TimeOfDelivery { get; set; }
        public virtual User user { get; set; }
    }
}
