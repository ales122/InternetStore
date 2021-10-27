using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.DAO.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(UsersContext context) : base(context)
        {

        }

        public IEnumerable<Movie> GetAllLikedUserMovies(User user)
        {
            return user.LikedMovies.ToList();
        }

        public IEnumerable<Comment> GetAllUserComments(User user)
        {
            return user.Comments.ToList();
        }

        public IEnumerable<Warning> GetUserWarnings(User user)
        {
            return user.Warnings.ToList();
        }
    }
}
