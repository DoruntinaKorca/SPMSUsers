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
    public class GetAllCitiesForCountry
    {
        public class Query : IRequest<List<CityDto>>
        {
            public int CountryId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<CityDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cities = await _context.Cities
                    .Where(x=>x.CountryId == request.CountryId)
                    .ToListAsync();
                var result = _mapper.Map<List<CityDto>>(cities);
                return result;
            }
        }
    }
}
