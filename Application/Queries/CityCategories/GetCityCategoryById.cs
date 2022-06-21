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
    public class GetCityCategoryById
    {
        public class Query : IRequest<Result<CityCategoryDto>>
        {
            public int CityCategoryId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<CityCategoryDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<CityCategoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cityCategory = await _context.CityCategories.FirstOrDefaultAsync(x => x.CityCategoryId == request.CityCategoryId);

                if (cityCategory == null) return null;

                var result = _mapper.Map<CityCategoryDto>(cityCategory);
               
                return Result<CityCategoryDto>.Success(result);
            }
        }
    }
}
