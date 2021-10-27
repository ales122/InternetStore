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
    public class GenreController : ControllerBase
    {
        private readonly GenreService _genreService;
        public GenreController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task Create(Genre country)
        {
            await _genreService.Add(country);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _genreService.GetAll();
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<Genre> GetById(Guid id)
        {
            return await _genreService.GetById(id);
        }

    }
}
