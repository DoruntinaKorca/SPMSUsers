using Application.Core;
using Application.DTOs.GenerationDtos;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Generations
{
    public class EditGeneration
    {
        public class Command : IRequest<Result<Unit>>
        {
            public GenerationDto GenerationDto { get; set; }

            public int GenerationId { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
             //  var map =  _mapper.Map<Generation>(request.Generation);

                var generation = await _context.Generations.FindAsync(request.GenerationId);

                if (generation == null) return null;
                _mapper.Map(request.GenerationDto, generation);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit Generation");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
