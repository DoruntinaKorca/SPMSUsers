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
    public class GetStudentsForFaculty
    {
        public class Query : IRequest<List<StudentDto>>
        {
            public int FacultyId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<StudentDto>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<StudentDto>> Handle(Query request, CancellationToken cancellationToken)
            {

                Console.WriteLine("blla blla-------------------> " + request.FacultyId);
                var students = await _context.Students
                    .Include(s => s.Generation)
                    .Include(s => s.User)
                .Where(a => a.User.UsersFaculties.Any(x => x.FacultyID == request.FacultyId))
                .ToListAsync();

                var result = _mapper.Map<List<StudentDto>>(students);
                /*
                .Select(x => new UsersFaculty
                {
                    FacultyID = x.FacultyID,
                    UserID = x.UserID
                }).Where(u => u.FacultyID == request.FacultyId)
                .ToListAsync(); */



                /*

                Console.WriteLine("blla blla"+request.FacultyId);
                var students = await _context.UsersFaculties
                    .ToListAsync(); */
                /*
                Console.WriteLine("blla blla"+request.FacultyId);
                var students =await  _context.UsersFaculties
                    .Select(x => new UsersFaculty
                    {
                        FacultyID = x.FacultyID,
                        UserID = x.UserID
                    }).Where(u=>u.FacultyID == request.FacultyId)
                    .ToListAsync();
                */


                /*`
                .Include(x => x.UsersFaculties)
                .Where(a => a.UsersFaculties.Any(x => x.FacultyID == request.FacultyId))
                .ToListAsync(); */

                /*
                .Users
                .Include(x => x.UsersFaculties.Where(y=>y.FacultyID == request.FacultyId))
                .ToListAsync(); */


                /*
                .FromSqlRaw($"SELECT * FROM AspNetUsers INNER JOIN Students On AspNetUsers.Id = Students.StudentId INNER JOIN" +
                $" UsersFaculties ON UsersFaculties.FacultyID  WHERE UsersFaculties.FacultyID='{request.FacultyId}'")
                .ToListAsync();  */

                /*
                .Include(b=>b.User)
                 .ThenInclude(x=>x.UsersFaculties)
                .Where(a=>a.User.UsersFaculties.Any(x=>x.FacultyID == request.FacultyId))
                
                .ToListAsync();
                 */

                return result;
            }
        }
    }
}
