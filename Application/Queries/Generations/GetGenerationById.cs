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
    public class GetGenerationById
    {
        public class Query : IRequest<Result<GeneralGenerationDto>>
        {
            public int GenerationId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<GeneralGenerationDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<GeneralGenerationDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var generation = await _context.Generations.FirstOrDefaultAsync(x => x.GenerationId == request.GenerationId);

                if (generation == null) return null;
                
                var result = _mapper.Map<GeneralGenerationDto>(generation);
                
                return Result<GeneralGenerationDto>.Success(result);
            }
        }
    }
}
