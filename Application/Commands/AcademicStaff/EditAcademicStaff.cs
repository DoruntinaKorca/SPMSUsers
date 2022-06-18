using Application.DTOs.AcademicStaffDtos;
using AutoMapper;
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
    public class EditAcademicStaff
    {
        public class Command : IRequest
        {
            public EditAcademicStaffDto AcademicStaffDto { get; set; }

            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly IMapper _mapper;
            private readonly UsersContext _context;

            public Handler(IMapper mapper, UsersContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                var student = await _context.AcademicStaffs.FindAsync(user.Id);

                _mapper.Map(request.AcademicStaffDto, user);

                _mapper.Map(request.AcademicStaffDto, student);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
