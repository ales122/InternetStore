using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.DAO.Repositories
{
    public class CountryRepository:GenericRepository<Country>,ICountryRepository
    {
        public CountryRepository(UsersContext context):base(context)
        {

        }
    }
}
