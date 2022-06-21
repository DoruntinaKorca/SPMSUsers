using Application.Core;
using Application.DTOs.UserDtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    public class GetUserById
    {
        public class Query : IRequest<Result<GeneralUserResponse>>
        { 
            public Guid UserId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<GeneralUserResponse>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<GeneralUserResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(x=>x.Id == request.UserId).Select(x => new User
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    Email = x.Email,
                    ParentName = x.ParentName,
                    Surname = x.Surname,
                    DateOfBirth = x.DateOfBirth,
                    AddressDetails = x.AddressDetails,
                    Gender = x.Gender,
                    PersonalNumber = x.PersonalNumber,
                    DateRegistered = x.DateRegistered,
                    ProfilePictureURL = x.ProfilePictureURL,
                    PhoneNumber = x.PhoneNumber,
                    City = new City
                    {
                        CityId = x.City.CityId,
                        CityName = x.City.CityName,
                        ZIPCode = x.City.ZIPCode,
                        Country = new Country
                        {
                            CountryId = x.City.Country.CountryId,
                            CountryName = x.City.Country.CountryName
                        }
                    }

                }).FirstOrDefaultAsync();



                var result = _mapper.Map<GeneralUserResponse>(user);

               var userRole= await _context.UserRoles.Where(ur => ur.UserId == request.UserId).FirstOrDefaultAsync();

              

              var role= await _context.Roles.Where(n => n.Id == userRole.RoleId).FirstOrDefaultAsync();



                result.Role = _mapper.Map<RoleDto>(role);

                return Result<GeneralUserResponse>.Success(result);

            }
        }
    }
}
