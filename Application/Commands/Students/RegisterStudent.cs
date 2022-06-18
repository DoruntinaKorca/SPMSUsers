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
    public class RegisterStudent
    {
        public class Command : IRequest
        {
            public RegisterStudentDto RegisterStudentDto { get; set; }

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

                var user = _mapper.Map<User>(request.RegisterStudentDto);

                user.Id = Guid.NewGuid();

                user.DateRegistered = DateTime.Now;

                var student = _mapper.Map<Student>(request.RegisterStudentDto);


                var userFaculty = new UsersFaculty
                {
                    FacultyID = request.FacultyId,
                    //User = user,
                    UserID = user.Id
                };


                student.StudentId = user.Id;
                student.GenerationId = 1; // krejt qe regjistrohet tash kane me qene te ketij viti TO DO

                Console.WriteLine("---------------------->>>>>>>>>>>>> useri " + user.Id);
                Console.WriteLine("---------------------->>>>>>>>>>>>>  studenti" + student.StudentId);
                Console.WriteLine("---------------------->>>>>>>>>>>>> fkfkfkfk " + userFaculty.UserID);


                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();

                await _context.UsersFaculties.AddAsync(userFaculty);

                try
                {

                    await _context.Students.AddAsync(student);


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
