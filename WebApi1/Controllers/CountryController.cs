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
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;
        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task Create(Country country)
        {
           await _countryService.Add(country);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _countryService.GetAll();
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<Country> GetById(Guid id)
        {
            return await _countryService.GetById(id);
        }
    }
}
