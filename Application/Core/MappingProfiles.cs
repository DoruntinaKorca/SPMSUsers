using Application.DTOs;
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
            CreateMap<GenerationDto, Generation>();


            CreateMap<Generation, GenerationDto>();


            CreateMap<City, CityDto>();


            CreateMap<IdentityRole<Guid>, RoleDto>()
                 .ForPath(dest => dest.RoleId,
                            opts => opts.MapFrom(src =>
                                src.Id));

            CreateMap<Country, CountryDto>();

            CreateMap<AcademicLevel, AcademicLevelDto>();
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
                                    dto.Country = rc.Mapper.Map<CountryDto>(user.City.Country);
                                });


            //map for getting student profile info
            CreateMap<Student, GeneralStudentDto>()
                .ForPath(dest => dest.Generation,
                opts => opts.MapFrom(src => src.Generation))
                .ForPath(dest =>dest.FirstName,
                opts=>opts.MapFrom(src => src.User.FirstName))
                .ForPath(dest => dest.Surname,
                opts => opts.MapFrom(src => src.User.Surname))
                .ForPath(dest => dest.Specializations, opts => opts
                .MapFrom(src => src.Specializations.Select(x => x.SpecializationId).ToList()))
                .ForPath(dest => dest.LectureGroups, opts => opts
                .MapFrom(src => src.LectureGroups.Select(x => x.LectureGroupId).ToList()))
                .ForPath(dest => dest.Faculties, opts => opts
                .MapFrom(src => src.User.UsersFaculties.Select(x => x.FacultyID).ToList() ));


           
            //map for getting academicStaff profile info
            CreateMap<AcademicStaff, AcademicStaffDto>()
                .ForPath(dest=>dest.AcademicLevel,
                opts=>opts.MapFrom(src=>src.AcademicLevel))
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
