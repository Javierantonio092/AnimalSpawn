using AnimalSpawn.Domain.DTOs;
using AnimalSpawn.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSpawn.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Animal
            CreateMap<Animal, AnimalResponseDto>();
            CreateMap<Animal, AnimalRequestDto>();
            CreateMap<AnimalRequestDto, RfidTag>()
                .ForMember(destination => destination.Tag, act => act.MapFrom(source => source.RfidTag));            
            CreateMap<AnimalRequestDto, Animal>()
                .ForMember(destination => destination.RfidTag, act => act.MapFrom(source => source))
                .AfterMap((source, destination) =>
                {
                    destination.CreateAt = DateTime.Now;
                    destination.UpdateAt = DateTime.Now;
                    destination.RfidTag.UpdateAt = DateTime.Now;
                    destination.RfidTag.CreateAt = DateTime.Now;
                    destination.CreatedBy = 3;
                    destination.Status = true;                     
                });
            CreateMap<AnimalResponseDto, Animal>();          
            //Country
            CreateMap<Country, CountryRequestDto>();
            CreateMap<Country, CountryResponseDto>();
            CreateMap<CountryRequestDto, Country>().AfterMap(
                (source, destination) =>
                {
                    destination.CreateAt = DateTime.Now;
                    destination.CreatedBy = 3;
                    destination.Status = true;
                });
            CreateMap<CountryResponseDto, Country>();
        }
    }

}
