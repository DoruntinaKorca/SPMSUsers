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
        public class Query : IRequest<GeneralGenerationDto>
        {
            public int GenerationId { get; set; }
        }
        public class Handler : IRequestHandler<Query, GeneralGenerationDto>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GeneralGenerationDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var generation = await _context.Generations.FirstOrDefaultAsync(x => x.GenerationId == request.GenerationId);
                var result = _mapper.Map<GeneralGenerationDto>(generation);
                return result;
            }
        }
    }
}
