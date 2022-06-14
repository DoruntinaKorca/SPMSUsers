using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.AdministrativeStaff
{
    public class GetAdministrativeStaffProfile
    {
        public class Query : IRequest<AdministrativeStaffDto>
        {
            public Guid AdministrativeStaffId { get; set; }
        }
        public class Handler : IRequestHandler<Query, AdministrativeStaffDto>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AdministrativeStaffDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var administrativeStaff = await _context.AdministrativeStaffs
                   .Include(a => a.User)
                    .FirstOrDefaultAsync(s => s.AdministrativeStaffId == request.AdministrativeStaffId);

                var result = _mapper.Map<AdministrativeStaffDto>(administrativeStaff);

                return result;

            }
        }
    }
}
