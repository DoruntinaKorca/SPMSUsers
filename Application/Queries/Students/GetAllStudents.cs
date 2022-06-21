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
    public class GetAllStudents
    {
        public class Query : IRequest<Result<List<GeneralStudentDto>>>
        {

        }
        public class Handler : IRequestHandler<Query, Result<List<GeneralStudentDto>>>
        {
            private readonly IMapper _mapper;
            private readonly UsersContext _context;

            public Handler(IMapper mapper, UsersContext context)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<List<GeneralStudentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await _context.Students
                       .Select(x => new Student
                       {
                           StudentId = x.StudentId,
                           User = x.User,
                           Generation = x.Generation,
                           FileNumber = x.FileNumber,
                           Specializations = x.Specializations,
                           LectureGroups = x.LectureGroups,
                       })
                    .ToListAsync();

                var result = _mapper.Map<List<GeneralStudentDto>>(students);

                return Result<List<GeneralStudentDto>>.Success(result);
            }
        }
    }
}
