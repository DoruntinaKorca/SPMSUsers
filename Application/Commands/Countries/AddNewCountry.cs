using Application.DTOs.CountryDtos;
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

namespace Application.Commands.Countries
{
    public class AddNewCountry
    {
        public class Command : IRequest
        {
            public AddCountryDto CountryDto { get; set; }
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
                var country = _mapper.Map<Country>(request.CountryDto);

                await _context.Countries.AddAsync(country);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
