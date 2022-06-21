using Application.Core;
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
    public class DeleteAdministrativeStaff
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid AdministrativeStaffId { get; set; }
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
                var administrativeStaff = await _context.Users.FindAsync(request.AdministrativeStaffId);

                if (administrativeStaff == null) return null;

                _context.Remove(administrativeStaff);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete Administrative Staff");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
