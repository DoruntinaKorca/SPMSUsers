using Application.Core;
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
        public class Command : IRequest<Result<Unit>>
        {
            public EditAdministrativeStaffDto AdministrativeStaffDto { get; set; }

            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly UsersContext _context;

            public Handler(IMapper mapper, UsersContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                var administrativeStaff = await _context.AdministrativeStaffs.FindAsync(user.Id);

                if (administrativeStaff == null) return null;

                _mapper.Map(request.AdministrativeStaffDto, user);

                _mapper.Map(request.AdministrativeStaffDto, administrativeStaff);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit Administrative Staff");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
