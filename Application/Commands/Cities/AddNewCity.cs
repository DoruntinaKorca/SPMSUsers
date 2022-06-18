using Application.DTOs.CityDtos;
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

namespace Application.Commands.Cities
{
    public class AddNewCity
    {
        public class Command : IRequest
        {
            public AddCityDto CityDto { get; set; }

            public int CountryId { get; set; }

            public int CityCategoryId { get; set; }
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
                var city = _mapper.Map<City>(request.CityDto);

                city.CountryId = request.CountryId;

                city.CategoryId = request.CityCategoryId;

                await _context.Cities.AddAsync(city);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
