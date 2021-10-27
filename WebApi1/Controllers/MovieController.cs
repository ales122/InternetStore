using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task Create(Movie movie)
        {
            await _movieService.Add(movie);
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _movieService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Movie> GetById(Guid id)
        {
            return await _movieService.GetById(id);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<string> Remove(Guid id)
        {
          return  await _movieService.Remove(id);
        }
    }
}
