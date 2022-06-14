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
        public class Command : IRequest
        {
            public Guid AdministrativeStaffId { get; set; }
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
                var administrativeStaff = await _context.Users.FindAsync(request.AdministrativeStaffId);

                _context.Remove(administrativeStaff);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
