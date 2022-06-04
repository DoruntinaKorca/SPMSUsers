using Application.DTOs;
using Application.Queries.AcademicStaff;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AcademicStaffController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<AcademicStaffDto>>> GetAllAcademicStaff()
        {
            return await Mediator.Send(new GetAllAcademicStaff.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicStaffDto>> GetAcademicStaffProfile(Guid id)
        {
            return await Mediator.Send(new GetAcademicStaffProfile.Query { AcademicStaffId = id});
        }
    }
}
