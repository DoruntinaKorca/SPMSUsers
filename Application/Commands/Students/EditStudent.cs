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
    public class EditStudent
    {
        public class Command : IRequest<Result<Unit>>
        {
            public EditStudentDto StudentDto { get; set; }

            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly UsersContext _context;

            public Handler(IMapper mapper, UsersContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                var student = await _context.Students.FindAsync(user.Id);

                if (student == null) return null;

                _mapper.Map(request.StudentDto, user);

                _mapper.Map(request.StudentDto, student);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit Student");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
