using Application.AsyncDataServices;
using Application.Core;
using Application.DTOs.UserDtos;
using AutoMapper;
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
    public class DeleteStudent
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid StudentId { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;
            private readonly IMessageBusClient _messageBusClient;

            public Handler(UsersContext context, IMapper mapper, IMessageBusClient messageBusClient)
            {
                _context = context;
                _mapper = mapper;
                _messageBusClient = messageBusClient;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
               var student = await _context.Users.FindAsync(request.StudentId);

                if (student == null) return null;

                try
                {
                    var deletUserPublishedDto = _mapper.Map<DeleteUserPublishedDto>(student);
                    deletUserPublishedDto.Event = "Deleted_User_Published";
                    _messageBusClient.DeletUser(deletUserPublishedDto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"---> Could not send asynchronously: {ex.Message}");
                }


                _context.Remove(student);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete Student");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
