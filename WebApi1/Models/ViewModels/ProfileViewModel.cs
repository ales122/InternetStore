using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
