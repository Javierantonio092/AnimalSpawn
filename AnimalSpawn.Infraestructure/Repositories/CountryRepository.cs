using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using AnimalSpawn.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AnimalSpawn.Infrastructure.Repositories
{
    /*
    public class CountryRepository : ICountryRepository
    {
        private readonly AnimalSpawnContext _context;

        public CountryRepository(AnimalSpawnContext context)
        {
            this._context = context;
        }

        public async Task AddCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var country = await _context.Countries.ToListAsync();
            return country;
        }

        public async Task<Country> GetCountry(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(country => country.Id == id);
            return country;
        }
    }
    */
}
