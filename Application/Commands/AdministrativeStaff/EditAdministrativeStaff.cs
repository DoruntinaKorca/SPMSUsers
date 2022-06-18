using Application.DTOs.AdministrativeStaffDtos;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AdministrativeStaff
{
    public class EditAdministrativeStaff
    {
        public class Command : IRequest
        {
            public EditAdministrativeStaffDto AdministrativeStaffDto { get; set; }

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

                var student = await _context.AdministrativeStaffs.FindAsync(user.Id);

                _mapper.Map(request.AdministrativeStaffDto, user);

                _mapper.Map(request.AdministrativeStaffDto, student);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
