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

namespace Application.Queries.Users
{
    public class GetUserFaculty
    {
        public class Query : IRequest<UsersFaculty>
        {
            public int FacultyId { get; set; }
        }
        public class Handler : IRequestHandler<Query, UsersFaculty>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;

            public Handler(UsersContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UsersFaculty> Handle(Query request, CancellationToken cancellationToken)
            {
                Console.WriteLine("blla blla---------------->" + request.FacultyId);
                var students = await _context.UsersFaculties
                    .Select(x => new UsersFaculty{
                    FacultyID = x.FacultyID,
UserID = x.UserID
}).FirstOrDefaultAsync();
                  


                // var result = _mapper.Map<PersonalProfileDto>(user);
                return students;

            }
        }
    }
}
