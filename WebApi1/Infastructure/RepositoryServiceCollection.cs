using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.DAO;
using WebApi1.DAO.Repositories;

namespace WebApi1.Infastructure
{
    public static  class RepositoryServiceCollection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            return services;
        }
    }
}
