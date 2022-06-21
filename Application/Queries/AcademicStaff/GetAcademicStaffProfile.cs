using Application.Core;
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
        public class Query : IRequest<Result<AcademicStaffDto>>
        {
            public Guid AcademicStaffId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<AcademicStaffDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AcademicStaffDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var academicStaff = await _context.AcademicStaffs
                    .Include(a => a.AcademicLevel)
                  .Include(a => a.User)
                   .FirstOrDefaultAsync(s => s.AcademicStaffId == request.AcademicStaffId);

                if (academicStaff == null) return null;
               
                var result = _mapper.Map<AcademicStaffDto>(academicStaff);

                return Result<AcademicStaffDto>.Success(result);

            }
        }
    }
}
