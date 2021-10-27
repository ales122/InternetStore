using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.DAO.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(UsersContext context) : base(context)
        {

        }
        public IEnumerable<Movie> GetMoviesWithHighMark()
        {
            throw new NotImplementedException();
        }
    }
}
