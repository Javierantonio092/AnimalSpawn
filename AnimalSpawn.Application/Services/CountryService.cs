using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSpawn.Application.Services
{
    public class CountryService : ICountryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddCountry(Country country)
        {
            Expression<Func<Country, bool>> exprCountry = item => item.Name == country.Name;
            var countries = _unitOfWork.CountryRepository.FindByCondition(exprCountry);
            if (countries.Any()) throw new Exception("This country name already exist.");

            await _unitOfWork.CountryRepository.Add(country);
        }

        public async Task DeleteCountry(int id)
        {
            await _unitOfWork.CountryRepository.Delete(id);
        }

        public IEnumerable<Country> GetCountries()
        {
            return _unitOfWork.CountryRepository.GetAll();
        }

        public async Task<Country> GetCountry(int id)
        {
            return await _unitOfWork.CountryRepository.GetById(id);
        }

        public async Task UpdateCountry(Country country)
        {
            _unitOfWork.CountryRepository.Update(country);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
