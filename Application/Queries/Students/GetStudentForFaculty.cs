using Application.DTOs.StudentDtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Students
{
    public class GetStudentForFaculty
    {
        public class Query : IRequest<GeneralStudentDto>
        {
            public int FacultyId { get; set; }
            public Guid StudentId { get; set; }
        }
        public class Handler : IRequestHandler<Query, GeneralStudentDto>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GeneralStudentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var student = await _context.Students
                    .Include(u => u.User.UsersFaculties)
                    .Where(a => a.User.UsersFaculties.Any(x => x.FacultyID == request.FacultyId))
                    .Select(x => new Student
                    {
                        StudentId = x.StudentId,
                        User = x.User,
                        Generation = x.Generation,
                        FileNumber = x.FileNumber,
                        Specializations = x.Specializations,
                        LectureGroups = x.LectureGroups,
                    })
                    .FirstOrDefaultAsync(s => s.StudentId == request.StudentId);


                var result = _mapper.Map<GeneralStudentDto>(student);
                return result;

            }
        }
    }
}
