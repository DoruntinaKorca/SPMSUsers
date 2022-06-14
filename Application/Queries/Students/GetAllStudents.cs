using Application.DTOs;
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
        public class Query : IRequest<List<GeneralStudentDto>>
        {

        }
        public class Handler : IRequestHandler<Query, List<GeneralStudentDto>>
        {
            private readonly IMapper _mapper;
            private readonly UsersContext _context;

            public Handler(IMapper mapper, UsersContext context)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<GeneralStudentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await _context.Students
                    .Include(s=>s.Generation)
                    .Include(s => s.User)
                    .ToListAsync();

                var result = _mapper.Map<List<GeneralStudentDto>>(students);

                return result;
            }
        }
    }
}
