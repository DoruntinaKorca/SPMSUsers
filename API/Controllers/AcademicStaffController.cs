using Application.Commands.AcademicStaff;
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


        [HttpGet("getAcademicStaffForFaculty/{facultyId}")]
        public async Task<ActionResult<List<AcademicStaffDto>>> GetStudentsForFaculty(int facultyId)
        {
            return await Mediator.Send(new GetAcademicStaffForFaculty.Query { FacultyId = facultyId });
        }


        [HttpPost("{facultyId}")]
        public async Task<IActionResult> RegisterAcademicStaff(RegisterAcademicStaffDto academicStaff, int facultyId)
        {
            return Ok(await Mediator.Send(new RegisterAcademicStaff.Command { RegisterAcademicStaffDto = academicStaff, FacultyId = facultyId}));
        }


        [HttpDelete("{academicStaffId}")]
        public async Task<IActionResult> DeleteAcademicStaff(Guid academicStaffId)
        {
            return Ok(await Mediator.Send(new DeleteAcademicStaff.Command { AcademicStaffId = academicStaffId }));

        }

    }
}
