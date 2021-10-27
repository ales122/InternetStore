using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.DAO.Repositories
{
    public class GenreRepository:GenericRepository<Genre>,IGenreRepository
    {
        public GenreRepository(UsersContext usersContext) : base(usersContext)
        {

        }
    }
}
