using Application.Core;
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
        public class Command : IRequest<Result<Unit>>
        {
            public AddCountryDto CountryDto { get; set; }
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
                var country = _mapper.Map<Country>(request.CountryDto);

                await _context.Countries.AddAsync(country);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to add new Country");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
