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
            CreateMap<GenerationDto, Generation>();


            CreateMap<Country, CountryDto>();


            //map for getting personal profile of a user
            CreateMap<User, PersonalProfileDto>()
                .ForPath(dest => dest.City,
                            opts => opts.MapFrom(src =>
                                src.City.CityName))
                .ForPath(dest => dest.CityCategory,
                            opts => opts.MapFrom(src =>
                                src.City.CityCategory.CategoryName))
                .ForPath(dest => dest.Country,
                            opts => opts.MapFrom(src =>
                                src.City.Country.CountryName));


            //map for getting student profile info
            CreateMap<Student, StudentDto>()
                .ForPath(dest => dest.Generation,
                opts => opts.MapFrom(src => src.Generation.Name))
                .ForPath(dest =>dest.FirstName,
                opts=>opts.MapFrom(src => src.User.FirstName))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname));


           
            //map for getting academicStaff profile info
            CreateMap<AcademicStaff, AcademicStaffDto>()
                .ForPath(dest=>dest.AcademicLevel,
                opts=>opts.MapFrom(src=>src.AcademicLevel.Name))
                .ForPath(dest => dest.FirstName,
                opts => opts.MapFrom(src => src.User.FirstName))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname));


            //map for getting academicStaff profile info
            CreateMap<AdministrativeStaff, AdministrativeStaffDto>()
                .ForPath(dest => dest.FirstName,
                opts => opts.MapFrom(src => src.User.FirstName))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname));




            //map for registering a student
            CreateMap<RegisterStudentDto, User>()
                .ForMember(dest => dest.Id,
               opts => opts.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.PasswordHash,
               opts => opts.MapFrom(src => src.Password));
           

            CreateMap<RegisterStudentDto, Student>().ForMember(dest => dest.StudentId,
               opts => opts.MapFrom(src => src.StudentId));


            
            //maps for registering academic staff
            CreateMap<RegisterAcademicStaffDto, User>()
                .ForMember(dest => dest.Id,
               opts => opts.MapFrom(src => src.AcademicStaffId))
                .ForMember(dest => dest.PasswordHash,
               opts => opts.MapFrom(src => src.Password));

            CreateMap<RegisterAcademicStaffDto, AcademicStaff>()
                .ForMember(dest => dest.AcademicStaffId,
              opts => opts.MapFrom(src => src.AcademicStaffId))
                .ForMember(dest => dest.AcademicLevelId,
              opts => opts.MapFrom(src => src.AcademicLevelId));


            //maps for registering administrative staff 
            CreateMap<RegisterAdministrativeStaffDto, User>()
              .ForMember(dest => dest.Id,
             opts => opts.MapFrom(src => src.AdministrativeStaffId))
              .ForMember(dest => dest.PasswordHash,
             opts => opts.MapFrom(src => src.Password));


            CreateMap<RegisterAdministrativeStaffDto, AdministrativeStaff>()
              .ForMember(dest => dest.AdministrativeStaffId,
            opts => opts.MapFrom(src => src.AdministrativeStaffId));


            //maps for editing a student
            CreateMap<EditStudentDto, User>();

            CreateMap<EditStudentDto, Student>();
        }
    }
}
