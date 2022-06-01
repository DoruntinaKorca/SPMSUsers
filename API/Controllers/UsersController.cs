using Application.DTOs;
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
        public async Task<ActionResult<List<PersonalProfileDto>>> GetAllUsers()
        {
            return await Mediator.Send(new GetAllUsers.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalProfileDto>> GetUserById(Guid id)
        {
            return await Mediator.Send(new GetUserById.Query { UserId = id });
        }
    }
}
