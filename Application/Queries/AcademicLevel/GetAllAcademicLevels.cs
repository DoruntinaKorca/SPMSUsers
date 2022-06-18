using Application.DTOs.AcademicLevelDtos;
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

namespace Application.Queries.AcademicLevel
{
    public class GetAllAcademicLevels
    {
        public class Query : IRequest<List<AcademicLevelDto>>
        {

        }
        public class Handler : IRequestHandler<Query, List<AcademicLevelDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AcademicLevelDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var academicLevels = await _context.AcademicLevels.ToListAsync();

                var result = _mapper.Map<List<AcademicLevelDto>>(academicLevels);

                return result;
            }
        }
    }
}
