﻿using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AcademicLevel
{
    public class AddNewAcademicLevel
    {
        public class Command : IRequest
        {
            public Domain.AcademicLevel AcademicLevel { get; set; }
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
              //  var country = _mapper.Map<Country>(request.CountryDto);

                await _context.AcademicLevels.AddAsync(request.AcademicLevel);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
