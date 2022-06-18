using Application.DTOs.AcademicLevelDtos;
using Application.DTOs.AcademicStaffDtos;
using Application.DTOs.AdministrativeStaffDtos;
using Application.DTOs.CityCategoryDtos;
using Application.DTOs.CityDtos;
using Application.DTOs.CountryDtos;
using Application.DTOs.GenerationDtos;
using Application.DTOs.StudentDtos;
using Application.DTOs.UserDtos;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
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
            /*----------------->SpecializationsProfiles<--------------------*/
            CreateMap<SpecializationDto, StudentsSpecialization>();



            /*----------------->LectureGroupProfiles<--------------------*/
            CreateMap<LectureGroupDto, StudentsLectureGroup>();




            /*----------------->AcademicLevelProfiles<--------------------*/
            CreateMap<AcademicLevelDto, AcademicLevel>();

            CreateMap<AcademicLevel, AcademicLevelDto>();








            /*----------------->CountryProfiles<--------------------*/
            CreateMap<EditCountryDto, Country>();

            CreateMap<Country, CountryDto>()
                .ForPath(dest => dest.Cities, opts => opts
                .MapFrom(src => src.Cities.ToList()));

            CreateMap<Country, CountryWOCityDto>();

            CreateMap<AddCountryDto, Country>();







            /*----------------->CityProfiles<--------------------*/
            CreateMap<City, CityDto>();

            CreateMap<AddCityDto, City>();

            CreateMap<CityCategory, CityCategoryDto>();







            /*----------------->GenerationProfiles<--------------------*/

            CreateMap<GenerationDto, Generation>();

            CreateMap<Generation, GenerationDto>();

            CreateMap<Generation, GeneralGenerationDto>();







            /*----------------->AdministrativeStaffProfiles<--------------------*/
            CreateMap<AdministrativeStaff, AdministrativeStaffDto>()
               .ForPath(dest => dest.FirstName,
               opts => opts.MapFrom(src => src.User.FirstName))
               .ForPath(dest => dest.Surname,
               opts => opts.MapFrom(src => src.User.Surname));

            //maps for registering administrative staff 
            CreateMap<RegisterAdministrativeStaffDto, User>()
              .ForMember(dest => dest.Id,
             opts => opts.MapFrom(src => src.AdministrativeStaffId))
              .ForMember(dest => dest.PasswordHash,
             opts => opts.MapFrom(src => src.Password));


            CreateMap<RegisterAdministrativeStaffDto, AdministrativeStaff>()
              .ForMember(dest => dest.AdministrativeStaffId,
            opts => opts.MapFrom(src => src.AdministrativeStaffId));

            //maps for editing administrativestaff
            CreateMap<EditAdministrativeStaffDto, User>();

            CreateMap<EditAdministrativeStaffDto, AdministrativeStaff>();









            /*----------------->AcademicStaffProfiles<--------------------*/
            //map for getting academicStaff profile info
            CreateMap<AcademicStaff, AcademicStaffDto>()
                .ForPath(dest => dest.AcademicLevel,
                opts => opts.MapFrom(src => src.AcademicLevel))
                .ForPath(dest => dest.FirstName,
                opts => opts.MapFrom(src => src.User.FirstName))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname));

            //maps for editing academicstaff
            CreateMap<EditAcademicStaffDto, User>();

            CreateMap<EditAcademicStaffDto, AcademicStaff>();

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









            /*----------------->StudentProfiles<--------------------*/
            //map for getting student profile info
            CreateMap<Student, GeneralStudentDto>()
                .ForPath(dest => dest.Generation,
                opts => opts.MapFrom(src => src.Generation))
                .ForPath(dest => dest.FirstName,
                opts => opts.MapFrom(src => src.User.FirstName))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname))
                .ForPath(dest => dest.Specializations, opts => opts
                .MapFrom(src => src.Specializations.Select(x => x.SpecializationId).ToList()))
                .ForPath(dest => dest.LectureGroups, opts => opts
                .MapFrom(src => src.LectureGroups.Select(x => x.LectureGroupId).ToList()))
                .ForPath(dest => dest.Faculties, opts => opts
                .MapFrom(src => src.User.UsersFaculties.Select(x => x.FacultyID).ToList()));

            //map for registering a student
            CreateMap<RegisterStudentDto, User>()
                .ForMember(dest => dest.Id,
               opts => opts.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.PasswordHash,
               opts => opts.MapFrom(src => src.Password));


            CreateMap<RegisterStudentDto, Student>().ForMember(dest => dest.StudentId,
               opts => opts.MapFrom(src => src.StudentId));

            //maps for editing a student
            CreateMap<EditStudentDto, User>();

            CreateMap<EditStudentDto, Student>();








            /*----------------->UserProfiles<--------------------*/
            //map for getting personal profile of a user
            CreateMap<User, GeneralUserResponse>()
                .ForPath(dest => dest.City,
                            opts => opts.MapFrom(src =>
                                src.City))

                 .ForPath(dest => dest.PhoneNumber,
                            opts => opts.MapFrom(src =>
                                src.PhoneNumber))
                 .ForPath(dest => dest.Email,
                            opts => opts.MapFrom(src =>
                                src.Email)).AfterMap((user, dto, rc) =>
                                {
                                    dto.Country = rc.Mapper.Map<CountryWOCityDto>(user.City.Country);
                                });



            CreateMap<IdentityRole<Guid>, RoleDto>()
                 .ForPath(dest => dest.RoleId,
                            opts => opts.MapFrom(src =>
                                src.Id));
            

        }
    }
}
