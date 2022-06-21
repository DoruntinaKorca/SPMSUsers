using Application.DTOs.UserDtos;
using Application.Queries.Users;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<GeneralUserResponse>>> GetAllUsers()
        {
            var users =  await Mediator.Send(new GetAllUsers.Query());
            return HandleResult(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralUserResponse>> GetUserById(Guid id)
        {
            var user= await Mediator.Send(new GetUserById.Query { UserId = id });
            return HandleResult(user);
        }


     
    
    }
}
