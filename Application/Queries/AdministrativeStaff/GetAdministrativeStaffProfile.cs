using Application.Core;
using Application.DTOs.AdministrativeStaffDtos;
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
        public class Query : IRequest<Result<AdministrativeStaffDto>>
        {
            public Guid AdministrativeStaffId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<AdministrativeStaffDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AdministrativeStaffDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var administrativeStaff = await _context.AdministrativeStaffs
                   .Include(a => a.User)
                    .FirstOrDefaultAsync(s => s.AdministrativeStaffId == request.AdministrativeStaffId);
                if (administrativeStaff == null) return null;
                var result = _mapper.Map<AdministrativeStaffDto>(administrativeStaff);

                return Result<AdministrativeStaffDto>.Success(result);

            }
        }
    }
}
