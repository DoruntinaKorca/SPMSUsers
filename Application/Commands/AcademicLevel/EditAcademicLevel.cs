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
        public class Command : IRequest
        {
            public AcademicLevelDto AcademicLevel { get; set; }

            public int AcademicLevelId { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
              
                var academicLevel = await _context.AcademicLevels.FindAsync(request.AcademicLevelId);

                _mapper.Map(request.AcademicLevel, academicLevel);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
