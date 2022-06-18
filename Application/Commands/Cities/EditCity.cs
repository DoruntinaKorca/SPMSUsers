using Application.DTOs.CityDtos;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Cities
{
    public class EditCity
    {
        public class Command : IRequest
        {
            public CityDto CityDto { get; set; }

            public int CityId { get; set; }
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

                var city = await _context.Cities.FindAsync(request.CityId);

                _mapper.Map(request.CityDto, city);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
