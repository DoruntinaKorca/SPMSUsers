using Application.DTOs;
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
   public class GetAllUsers
    {
        public class Query : IRequest<List<PersonalProfileDto>>
        {

        }
        public class Handler : IRequestHandler<Query, List<PersonalProfileDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<PersonalProfileDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users=await _context.Users
                    .Include(u=> u.Address)
                    .Include(u => u.Address.City)
                    .Include(u => u.Address.City.CityCategory)
                    .Include(u => u.Address.City.Country)
                    /*
                    .Select(u => new User
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Name = u.Name,
                        ParentName = u.ParentName,
                        Surname = u.Surname,
                        DateOfBirth=u.DateOfBirth,
                        AddressId = u.AddressId,
                        ProfilePictureURL=u.ProfilePictureURL,
                        Gender= u.Gender,
                        PersonalNumber=u.PersonalNumber,
                        DateRegistered=u.DateRegistered,
                        Address = u.Address
                    })*/.ToListAsync();

                var result =_mapper.Map<List<PersonalProfileDto>>(users);

                return  result;
            }
        }
    }
}
