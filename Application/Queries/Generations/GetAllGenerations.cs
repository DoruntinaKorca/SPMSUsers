using Application.Core;
using Application.DTOs.GenerationDtos;
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

namespace Application.Queries.Generations
{
    public class GetAllGenerations
    {
        public class Query : IRequest<Result<List<GeneralGenerationDto>>>
        {
        }
        public class Handler : IRequestHandler<Query, Result<List<GeneralGenerationDto>>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<GeneralGenerationDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var generations = await _context.Generations.ToListAsync();

                var result = _mapper.Map<List<GeneralGenerationDto>>(generations);

                return Result<List<GeneralGenerationDto>>.Success(result);
            }
        }
    }
}
