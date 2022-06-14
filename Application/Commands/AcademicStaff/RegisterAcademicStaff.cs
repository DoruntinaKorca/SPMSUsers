using Application.DTOs;
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

namespace Application.Commands.AcademicStaff
{
    public class RegisterAcademicStaff
    {
        public class Command : IRequest
        {
            public RegisterAcademicStaffDto RegisterAcademicStaffDto { get; set; }

            public int FacultyId { get; set; }

         //   public int AcademicLevelId { get; set; }
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

            //   request.RegisterAcademicStaffDto.AcademicLevelId = request.AcademicLevelId;

                var user = _mapper.Map<User>(request.RegisterAcademicStaffDto);

                user.Id = Guid.NewGuid();

                user.DateRegistered = DateTime.Now;

                var academicStaff = _mapper.Map<Domain.AcademicStaff>(request.RegisterAcademicStaffDto);


                var userFaculty = new UsersFaculty
                {
                    FacultyID = request.FacultyId,
                    //User = user,
                    UserID = user.Id
                };


                academicStaff.AcademicStaffId = user.Id;
               
                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();

                await _context.UsersFaculties.AddAsync(userFaculty);

                try
                {

                    await _context.AcademicStaffs.AddAsync(academicStaff);


                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine("blla blla------------> : " + e.Message);
                    Console.WriteLine("blla blla------------> : " + e.InnerException.Message);
                }



                return Unit.Value;


            }
        }
    }
}
