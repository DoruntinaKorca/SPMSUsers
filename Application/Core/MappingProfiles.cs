﻿using Application.DTOs;
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
                .ForPath(dest => dest.City,
                            opts => opts.MapFrom(src =>
                                src.AddressDetails.CityName))
                .ForPath(dest => dest.CityCategory,
                            opts => opts.MapFrom(src =>
                                src.AddressDetails.CityCategory.CategoryName))
                .ForPath(dest => dest.Country,
                            opts => opts.MapFrom(src =>
                                src.AddressDetails.Country.CountryName));


            CreateMap<Student, StudentDto>()
                .ForPath(dest => dest.Generation,
                opts => opts.MapFrom(src => src.Generation.Name))
                .ForPath(dest =>dest.Name,
                opts=>opts.MapFrom(src => src.User.Name))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname));


            CreateMap<AcademicStaff, AcademicStaffDto>()
                .ForPath(dest=>dest.AcademicLevel,
                opts=>opts.MapFrom(src=>src.AcademicLevel.Name))
                .ForPath(dest => dest.Name,
                opts => opts.MapFrom(src => src.User.Name))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname));

            CreateMap<AdministrativeStaff, AdministrativeStaffDto>()
                .ForPath(dest => dest.Name,
                opts => opts.MapFrom(src => src.User.Name))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname));

        }
    }
}
