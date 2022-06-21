using Application.Core;
using Application.DTOs.AcademicLevelDtos;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AcademicLevel
{
    public class EditAcademicLevel
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AcademicLevelDto AcademicLevel { get; set; }

            public int AcademicLevelId { get; set; }
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
              
                var academicLevel = await _context.AcademicLevels.FindAsync(request.AcademicLevelId);

                if (academicLevel == null) return null;

                _mapper.Map(request.AcademicLevel, academicLevel);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit Academic Level");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
