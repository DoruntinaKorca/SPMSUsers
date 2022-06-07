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
    public class GetUserById
    {
        public class Query : IRequest<PersonalProfileDto>
        { 
            public Guid UserId { get; set; }
        }
        public class Handler : IRequestHandler<Query, PersonalProfileDto>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PersonalProfileDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                     .Include(u => u.City)
                    .ThenInclude(u => u.CityCategory)
                    .Include(u => u.City.Country)
                    .FirstOrDefaultAsync(x => x.Id == request.UserId);
             

                var result = _mapper.Map<PersonalProfileDto>(user);
                return result;

            }
        }
    }
}
