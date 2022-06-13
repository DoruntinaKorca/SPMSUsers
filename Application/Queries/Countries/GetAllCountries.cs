﻿using Application.DTOs;
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

namespace Application.Queries.Countries
{
    public class GetAllCountries
    {
        public class Query : IRequest<List<CountryDto>>
        {

        }
        public class Handler : IRequestHandler<Query, List<CountryDto>>
        {
            private readonly IMapper _mapper;
            private readonly UsersContext _context;

            public Handler(IMapper mapper, UsersContext context)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<CountryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var countries = await _context.Countries
                    //.Include(s => s.Cities)
                    .ToListAsync();
                var result = _mapper.Map<List<CountryDto>>(countries);

                return result;
            }
        }
    }
}