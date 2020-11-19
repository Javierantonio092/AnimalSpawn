using AnimalSpawn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface ICountryServices
    {
        public IEnumerable<Country> GetCountries();
        public Task<Country> GetCountry(int id);
        public Task AddCountry(Country country);
        public Task UpdateCountry(Country country);
        public Task DeleteCountry(int id);

    }
}
