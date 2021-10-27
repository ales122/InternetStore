using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.DAO;
using WebApi1.DAO.Repositories;
using WebApi1.Models;

namespace WebApi1.DAO
{
    public interface ICountryRepository : IGenericRepository<Country>
    {

    }
}
