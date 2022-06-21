using Application.Core;
using Application.DTOs.CountryDtos;
using AutoMapper;
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
    public class EditCountry
    {
        public class Command : IRequest<Result<Unit>>
        {
            public EditCountryDto CountryDto { get; set; }

            public int CountryId { get; set; }
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

                var country = await _context.Countries.FindAsync(request.CountryId);

                if (country == null) return null;
                _mapper.Map(request.CountryDto, country);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit Country");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
