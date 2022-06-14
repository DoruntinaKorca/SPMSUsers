using Application.DTOs;
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

namespace Application.Queries.Countries
{
    public class GetCountryById
    {
        public class Query : IRequest<CountryDto>
        {
            public int CountryId { get; set; }
        }
        public class Handler : IRequestHandler<Query, CountryDto>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CountryDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var country = await _context.Countries
                    .FirstOrDefaultAsync(s => s.CountryId == request.CountryId);


                var result = _mapper.Map<CountryDto>(country);
                return result;

            }
        }
    }
}
