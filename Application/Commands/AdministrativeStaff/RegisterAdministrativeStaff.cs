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

namespace Application.Commands.AdministrativeStaff
{
    public class RegisterAdministrativeStaff
    {
        public class Command : IRequest
        {
            public RegisterAdministrativeStaffDto RegisterAdministrativeStaffDto { get; set; }

            public int FacultyId { get; set; }
      
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

                
                var user = _mapper.Map<User>(request.RegisterAdministrativeStaffDto);

                user.Id = Guid.NewGuid();

                user.DateRegistered = DateTime.Now;

                var administrativeStaff = _mapper.Map<Domain.AdministrativeStaff>(request.RegisterAdministrativeStaffDto);


                var userFaculty = new UsersFaculty
                {
                    FacultyID = request.FacultyId,
                    UserID = user.Id
                };


                administrativeStaff.AdministrativeStaffId = user.Id;

                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();

                await _context.UsersFaculties.AddAsync(userFaculty);

                try
                {

                    await _context.AdministrativeStaffs.AddAsync(administrativeStaff);


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
