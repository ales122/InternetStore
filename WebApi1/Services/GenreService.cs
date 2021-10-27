using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.DAO;
using WebApi1.DAO.Repositories;
using WebApi1.Models;

namespace WebApi1.Services
{
    public class GenreService
    {
        protected readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task Add(Genre genre)
        {
            await _genreRepository.Add(genre);
        }
        public async Task Remove(Genre genre)
        {
            await _genreRepository.Remove(genre);
        }
        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _genreRepository.GetAll();

        }

        public async Task<Genre> GetById(Guid id)
        {
            Genre genre = await _genreRepository.GetById(id);
            return genre;
        }
    }
}
