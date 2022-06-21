using Application.Core;
using AutoMapper;
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
    public class DeleteGeneration
    {
        public class Command : IRequest<Result<Unit>>
        {
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
            var generation = await _context.Generations.FindAsync(request.GenerationId);

                if (generation == null) return null;
            _context.Remove(generation);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete Generation");

                return Result<Unit>.Success(Unit.Value);
            }
    }
}
}
