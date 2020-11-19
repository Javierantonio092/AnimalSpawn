using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.DTOs;
using AnimalSpawn.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AnimalSpawn.Api.Responses;

namespace AnimalSpawn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryServices _service;
        private readonly IMapper _mapper;

        public CountryController(ICountryServices services, IMapper mapper)
        {
            this._service = services;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var countries =  _service.GetCountries();
            var countriesDto = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResponseDto>>(countries);
            var response = new ApiResponse<IEnumerable<CountryResponseDto>>(countriesDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await _service.GetCountry(id);
            var countryDto = _mapper.Map<Country, CountryResponseDto>(country);
            var response = new ApiResponse<CountryResponseDto>(countryDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CountryRequestDto countryDto)
        {
            var country = _mapper.Map<CountryRequestDto, Country>(countryDto);
            await _service.AddCountry(country);
            var countryResponseDto = _mapper.Map<Country, CountryResponseDto>(country);
            var response = new ApiResponse<CountryResponseDto>(countryResponseDto);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task <IActionResult> Delete(int id)
        {
            await _service.DeleteCountry(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CountryRequestDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            country.Id = id;
            country.UpdateAt = DateTime.Now;
            country.UpdatedBy = 2;

            await _service.UpdateCountry(country);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }
    }
}
