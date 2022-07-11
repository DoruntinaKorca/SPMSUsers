using Application.AsyncDataServices;
using Application.Core;
using Application.DTOs.AdministrativeStaffDtos;
using Application.DTOs.UserDtos;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public class Command : IRequest<Result<Unit>>
        {
            public RegisterAdministrativeStaffDto RegisterAdministrativeStaffDto { get; set; }

            public int FacultyId { get; set; }

            public IFormFile File { get; set; }

        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly UsersContext _context;
            private readonly IMapper _mapper;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IMessageBusClient _messageBusClient;

            public Handler(UsersContext context,
                IMapper mapper,
                IPhotoAccessor photoAccessor,
                 IMessageBusClient messageBusClient)
            {
                _context = context;
                _mapper = mapper;
                _photoAccessor = photoAccessor;
                _messageBusClient = messageBusClient;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                
                var user = _mapper.Map<User>(request.RegisterAdministrativeStaffDto);

                user.Id = Guid.NewGuid();

                user.DateRegistered = DateTime.Now;

                var photoUploadResult = _photoAccessor.AddPhoto(request.File);

                user.ProfilePictureURL = photoUploadResult.PublicId;


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

               
                    await _context.AdministrativeStaffs.AddAsync(administrativeStaff);


                await _context.SaveChangesAsync();

                var role = await _context.Roles.Where(x => x.Name.Equals("AdministrativeStaff")).FirstOrDefaultAsync();
                var userRoleDto = new UserRoleDto
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                };

                var userRole = _mapper.Map<IdentityUserRole<Guid>>(userRoleDto);

                await _context.UserRoles.AddAsync(userRole);

                var result = await _context.SaveChangesAsync() > 0;


                try
                {
                    var userPublishedDto = _mapper.Map<UserPublishedDto>(user);
                    userPublishedDto.Event = "User_Published";
                    _messageBusClient.PublishNewUser(userPublishedDto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"---> Could not send asynchronously: {ex.Message}");
                }


                if (!result) return Result<Unit>.Failure("Failed to add Register Administrative Staff");

                return Result<Unit>.Success(Unit.Value);


            }
        }
    }
}
