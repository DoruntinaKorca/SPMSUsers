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
    public class GetAllUsers
    {
        public class Query : IRequest<Result<List<GeneralUserResponse>>>
        {

        }
        public class Handler : IRequestHandler<Query, Result<List<GeneralUserResponse>>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<GeneralUserResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users=await _context.Users
                    .Include(u => u.City)
                    //.ThenInclude(u => u.CityCategory)
                    .Include(u => u.City.Country)
                    .ToListAsync();

                var result =_mapper.Map<List<GeneralUserResponse>>(users);

            
                
                return Result<List<GeneralUserResponse>>.Success(result);
            }
        }
    }
}
