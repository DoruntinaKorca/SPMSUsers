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

namespace Application.Commands.AcademicStaff
{
    public class DeleteAcademicStaff
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid AcademicStaffId { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;
            private readonly IMessageBusClient _messageBusClient;

            public Handler(UsersContext context,
                IMapper mapper,
                 IMessageBusClient messageBusClient)
            {
                _context = context;
                _mapper = mapper;
                _messageBusClient = messageBusClient;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var academicStaff = await _context.Users.FindAsync(request.AcademicStaffId);

                try
                {
                    var deletUserPublishedDto = _mapper.Map<DeleteUserPublishedDto>(academicStaff);
                    deletUserPublishedDto.Event = "Deleted_User_Published";
                    _messageBusClient.DeletUser(deletUserPublishedDto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"---> Could not send asynchronously: {ex.Message}");
                }
                if (academicStaff == null) return null;

                _context.Remove(academicStaff);

                var result = await _context.SaveChangesAsync() > 0;



                if (!result) return Result<Unit>.Failure("Failed to delete academicStaff");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
