using Application.Core;
using Application.DTOs.CityDtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Cities
{
    public class GetCityById
    {
        public class Query : IRequest<Result<CityDto>>
        {
            public int CityId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<CityDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<CityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var city = await _context.Cities.FirstOrDefaultAsync(x=>x.CityId == request.CityId);

                if (city == null) return null;
                  //  return Result<CityDto>.Failure("This city doesnt exist");

                var result = _mapper.Map<CityDto>(city);

                return Result<CityDto>.Success(result);
            }
        }
    }
}
