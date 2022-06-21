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
    public class GetAllAdministrativeStaff
    {
        public class Query : IRequest<Result<List<AdministrativeStaffDto>>>
        { }
        public class Handler : IRequestHandler<Query, Result<List<AdministrativeStaffDto>>>
        {
            private readonly IMapper _mapper;
            private readonly UsersContext _context;

            public Handler(IMapper mapper, UsersContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<AdministrativeStaffDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var administrativeStaff = await _context.AdministrativeStaffs
                   .Include(a => a.User)
                 .ToListAsync();

                var result = _mapper.Map<List<AdministrativeStaffDto>>(administrativeStaff);

                return Result <List<AdministrativeStaffDto>>.Success(result);
            }
        }
    }
}
