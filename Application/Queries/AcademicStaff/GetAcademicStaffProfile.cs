using Application.DTOs.AcademicStaffDtos;
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

namespace Application.Queries.AcademicStaff
{
    public class GetAcademicStaffProfile
    {
        public class Query : IRequest<AcademicStaffDto>
        {
            public Guid AcademicStaffId { get; set; }
        }
        public class Handler : IRequestHandler<Query, AcademicStaffDto>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AcademicStaffDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var academicStaff = await _context.AcademicStaffs
                    .Include(a => a.AcademicLevel)
                  .Include(a => a.User)
                   .FirstOrDefaultAsync(s => s.AcademicStaffId == request.AcademicStaffId);

                var result = _mapper.Map<AcademicStaffDto>(academicStaff);

                return result;

            }
        }
    }
}
