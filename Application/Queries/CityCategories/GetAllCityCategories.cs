using Application.Core;
using Application.DTOs.CityCategoryDtos;
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

namespace Application.Queries.CityCategories
{
    public class GetAllCityCategories
    {
        public class Query : IRequest<Result<List<CityCategoryDto>>>
        {
        }
        public class Handler : IRequestHandler<Query, Result<List<CityCategoryDto>>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<CityCategoryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cityCategories = await _context.CityCategories.ToListAsync();

                var result = _mapper.Map<List<CityCategoryDto>>(cityCategories);

                return Result <List<CityCategoryDto>>.Success(result);
            }
        }
    }
}
