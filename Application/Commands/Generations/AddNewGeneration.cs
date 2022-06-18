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
    public class AddNewGeneration
    {
        public class Command : IRequest
        {
            public GenerationDto GenerationDto { get; set; }

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

                var generation = _mapper.Map<Generation>(request.GenerationDto);

                    await _context.Generations.AddAsync(generation);

                    await _context.SaveChangesAsync();
                       
                return Unit.Value;


            }
        }
    }
}
