
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/u/[controller]")]
    [ApiController]
    public class LectureGroupsController : ControllerBase
    {
        public LectureGroupsController()
        {
        }

        [HttpPost]
        public ActionResult TestInboudConnection()
        {
            Console.WriteLine("-----> Inbound POST # USERS SERVICE");

            return Ok("INBOUND TEST FROM LECTUREGROUPS CONTROLLER");
        }
    }
}

