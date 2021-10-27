using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.DAO;
using WebApi1.Models;

namespace WebApi1.Services
{
    public class MovieService
    {
        protected readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task Add(Movie movie)
        {
           await _movieRepository.Add(movie);
        }
        public async Task<string> Remove(Guid id)
        {
            var movie =await _movieRepository.GetById(id);
            if(movie != null)
            {
              await _movieRepository.Remove(movie);
              return $"Movie with name \"{movie.Name}\" was succesfully deleted!"; 
            }
            return "Movie with this id doesn't exist!";
        }
        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _movieRepository.GetAll();
        }

        public async Task<Movie> GetById(Guid id)
        {
            Movie genre = await _movieRepository.GetById(id);
            return genre;
        }

   
    }
}
