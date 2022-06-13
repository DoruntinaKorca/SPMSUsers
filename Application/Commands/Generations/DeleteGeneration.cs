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
    {public class Command : IRequest
        {
            public int GenerationId { get; set; }
    }
    public class Handler : IRequestHandler<Command>
    {
        private readonly UsersContext _context;
        private readonly IMapper _mapper;

        public Handler(UsersContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var generation = await _context.Generations.FindAsync(request.GenerationId);

            _context.Remove(generation);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
}
