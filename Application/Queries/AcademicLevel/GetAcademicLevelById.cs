using Application.Core;
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
    public class GetAcademicLevelById
    {
        public class Query : IRequest<Result<AcademicLevelDto>>
        {
            public int AcademicLevelId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<AcademicLevelDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AcademicLevelDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var academicLevel = await _context.AcademicLevels.FirstOrDefaultAsync(x=>x.AcademicLevelId == request.AcademicLevelId);


                if (academicLevel == null) return null;

                var result = _mapper.Map<AcademicLevelDto>(academicLevel);

                return Result<AcademicLevelDto>.Success(result);
            }
        }
    }
}
