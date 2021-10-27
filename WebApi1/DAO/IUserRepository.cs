using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.DAO.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        IEnumerable<Comment> GetAllUserComments(User user);
        IEnumerable<Movie> GetAllLikedUserMovies(User user);
        IEnumerable<Warning> GetUserWarnings(User user);
        

    }
}
