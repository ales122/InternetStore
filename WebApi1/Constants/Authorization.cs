using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Admin,
            User
        }
        public const string default_email = "name@gmail.com";
        public const string default_password = "X1t4MxKd@";
        public const Roles default_role = Roles.User;
        public const int default_year = 15;
    }
}
