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
        public class Command : IRequest
        {
            public GenerationDto GenerationDto { get; set; }

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
             //  var map =  _mapper.Map<Generation>(request.Generation);

                var generation = await _context.Generations.FindAsync(request.GenerationId);

                _mapper.Map(request.GenerationDto, generation);
                
                await _context.SaveChangesAsync() ;

                return Unit.Value;
            }
        }
    }
}
