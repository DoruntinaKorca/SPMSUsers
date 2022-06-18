using Application.DTOs.StudentDtos;
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
    public class GetStudentsForGeneration
    {
        public class Query : IRequest<List<GeneralStudentDto>>
        {
            public int GenerationId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<GeneralStudentDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<GeneralStudentDto>> Handle(Query request, CancellationToken cancellationToken)
            {

                var students = await _context.Students
                    .Include(s => s.Generation)
                    .Include(s => s.User)
                .Where(a => a.GenerationId == request.GenerationId)
                .ToListAsync();

                var result = _mapper.Map<List<GeneralStudentDto>>(students);


                return result;
            }
        }
    }
}
