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
    public class GetStudentsForFaculty
    {
        public class Query : IRequest<Result<List<GeneralStudentDto>>>
        {
            public int FacultyId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<GeneralStudentDto>>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<GeneralStudentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {

              //  Console.WriteLine("blla blla-------------------> " + request.FacultyId);
                var students = await _context.Students
                    .Include(s => s.Generation)
                    .Include(s => s.User)
                .Where(a => a.User.UsersFaculties.Any(x => x.FacultyID == request.FacultyId))
                .ToListAsync();

                var result = _mapper.Map<List<GeneralStudentDto>>(students);
               

                return Result<List<GeneralStudentDto>>.Success(result);
            }
        }
    }
}
