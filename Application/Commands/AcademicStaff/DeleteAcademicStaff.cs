﻿using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AcademicStaff
{
    public class DeleteAcademicStaff
    {
        public class Command : IRequest
        {
            public Guid AcademicStaffId { get; set; }
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
                var academicStaff = await _context.Users.FindAsync(request.AcademicStaffId);

                _context.Remove(academicStaff);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}