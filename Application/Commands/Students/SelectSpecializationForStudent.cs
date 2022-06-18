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
    public class SelectSpecializationForStudent
    {
        public class Command : IRequest
        {
            public SpecializationDto Specialization { get; set; }
          //  public int SpecializationId { get; set; }
           // public Guid StudentId { get; set; }
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
               // var student = await _context.Students.FindAsync(request.StudentId);
               var specialization = _mapper.Map<StudentsSpecialization>(request.Specialization);

                await _context.StudentsSpecializations.AddAsync(specialization);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }

        }
    }
}
