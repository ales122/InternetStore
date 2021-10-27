using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.DAO;
using WebApi1.Models;

namespace WebApi1.Services
{
    public class CountryService
    {
        protected readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task Add(Country country)
        {
         await _countryRepository.Add(country);
        }
        public async Task Remove(Country country)
        {
            await _countryRepository.Remove(country);
        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _countryRepository.GetAll();
        
        }

        public async Task<Country> GetById(Guid id)
        {
            Country country = await _countryRepository.GetById(id);
            return country;
        }
    }
}
