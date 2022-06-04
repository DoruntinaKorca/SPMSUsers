using Application.DTOs;
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

namespace Application.Queries.Students
{
    public class GetStudentProfile
    {
        public class Query : IRequest<StudentDto>
        {
            public Guid StudentId { get; set; }
        }
        public class Handler : IRequestHandler<Query, StudentDto>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StudentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var student = await _context.Students
                    .Include(s => s.Generation)
                    .Include(s=>s.User)
                    .FirstOrDefaultAsync(s=>s.StudentId == request.StudentId);
             

                var result = _mapper.Map<StudentDto>(student);
                return result;

            }
        }
    }
}
