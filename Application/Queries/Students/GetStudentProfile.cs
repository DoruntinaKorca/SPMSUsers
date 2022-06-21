using Application.Core;
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
    public class GetStudentProfile
    {
        public class Query : IRequest<Result<GeneralStudentDto>>
        {
            public Guid StudentId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<GeneralStudentDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<GeneralStudentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var student = await _context.Students
                    .Include(u=>u.User.UsersFaculties)
                    .Select(x=> new Student
                    {
                        StudentId = x.StudentId,
                        User = x.User,
                        Generation = x.Generation,
                        FileNumber = x.FileNumber,
                        Specializations = x.Specializations,
                        LectureGroups = x.LectureGroups,
                    })
                    .FirstOrDefaultAsync(s=>s.StudentId == request.StudentId);

                if (student == null) return null;

                var result = _mapper.Map<GeneralStudentDto>(student);
                return Result<GeneralStudentDto>.Success(result);

            }
        }
    }
}
