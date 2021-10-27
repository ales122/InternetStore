using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.DAO
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        IEnumerable<Movie> GetMoviesWithHighMark();
    }
}
