using Application.Core;
using Application.DTOs.AcademicStaffDtos;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AcademicStaff
{
    public class EditAcademicStaff
    {
        public class Command : IRequest<Result<Unit>>
        {
            public EditAcademicStaffDto AcademicStaffDto { get; set; }

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

                var academicStaff = await _context.AcademicStaffs.FindAsync(user.Id);

                if (academicStaff == null) return null;

                _mapper.Map(request.AcademicStaffDto, user);

                _mapper.Map(request.AcademicStaffDto, academicStaff);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit academicStaff");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
