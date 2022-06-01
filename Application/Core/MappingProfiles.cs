using Application.DTOs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

           //source to target
            CreateMap<User, PersonalProfileDto>();

            
            CreateMap<User, PersonalProfileDto>()
                .ForPath(dest => dest.Street,
                  opts => opts.MapFrom(src =>
                      src.Address.StreetName))
                .ForPath(dest => dest.City,
                            opts => opts.MapFrom(src =>
                                src.Address.City.CityName))
                .ForPath(dest => dest.CityCategory,
                            opts => opts.MapFrom(src =>
                                src.Address.City.CityCategory.CategoryName))
                .ForPath(dest => dest.Country,
                            opts => opts.MapFrom(src =>
                                src.Address.City.Country.CountryName));


            /*
                .ForPath(dest => dest.City,
                            opts => opts.MapFrom(src =>
                                src.Address.City.CityName))
             */

        }
    }
}
