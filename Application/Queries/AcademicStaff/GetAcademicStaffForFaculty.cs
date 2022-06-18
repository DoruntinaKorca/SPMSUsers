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
    public class GetAcademicStaffForFaculty
    {
        public class Query : IRequest<List<AcademicStaffDto>>
        {
            public int FacultyId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<AcademicStaffDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AcademicStaffDto>> Handle(Query request, CancellationToken cancellationToken)
            {

               
                var staff = await _context.AcademicStaffs
                    .Include(s => s.AcademicLevel)
                    .Include(s => s.User)
                .Where(a => a.User.UsersFaculties.Any(x => x.FacultyID == request.FacultyId))
                .ToListAsync();

                var result = _mapper.Map<List<AcademicStaffDto>>(staff);


                return result;
            }
        }
    }
}
