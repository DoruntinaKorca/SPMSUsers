using Application.Core;
using Application.DTOs.StudentDtos;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Students
{
    public class SelectLectureGroupForStudent
    {
        public class Command : IRequest<Result<Unit>>
        {
            public LectureGroupDto LectureGroup { get; set; }
          
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // var student = await _context.Students.FindAsync(request.StudentId);
                var lectureGroup = _mapper.Map<StudentsLectureGroup>(request.LectureGroup);

                await _context.StudentsLectureGroups.AddAsync(lectureGroup);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to select Lecture Group");

                return Result<Unit>.Success(Unit.Value);
            }

        }
    }
}
