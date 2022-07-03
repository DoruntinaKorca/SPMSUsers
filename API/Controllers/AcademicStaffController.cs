using Application.Commands.AcademicStaff;
using Application.DTOs.AcademicStaffDtos;
using Application.Queries.AcademicStaff;
using Microsoft.AspNetCore.Http;
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
            var academicStaff =  await Mediator.Send(new GetAllAcademicStaff.Query());

            return HandleResult(academicStaff);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicStaffDto>> GetAcademicStaffProfile(Guid id)
        {
            var academicStaff = await Mediator.Send(new GetAcademicStaffProfile.Query { AcademicStaffId = id});
            return HandleResult(academicStaff);
        }


        [HttpGet("getAcademicStaffForFaculty/{facultyId}")]
        public async Task<ActionResult<List<AcademicStaffDto>>> GetAcademicStaffForFaculty(int facultyId)
        {
           var academicStaffForFaculty = await Mediator.Send(new GetAcademicStaffForFaculty.Query { FacultyId = facultyId });
            return HandleResult(academicStaffForFaculty);
        }


        [HttpPost("{facultyId}")]
        public async Task<IActionResult> RegisterAcademicStaff([FromForm] RegisterAcademicStaffDto academicStaff, [FromForm] int facultyId, [FromForm] IFormFile file)
        {
            return HandleResult(await Mediator.Send(new RegisterAcademicStaff.Command { RegisterAcademicStaffDto = academicStaff, FacultyId = facultyId,File=file}));
        }

        [HttpPut("{academicStaffId}")]
        public async Task<IActionResult> EditAcademicStaff(EditAcademicStaffDto academicStaff, Guid academicStaffId)
        {

            return HandleResult(await Mediator.Send(new EditAcademicStaff.Command { AcademicStaffDto = academicStaff, Id = academicStaffId }));
        }


        [HttpDelete("{academicStaffId}")]
        public async Task<IActionResult> DeleteAcademicStaff(Guid academicStaffId)
        {
            return HandleResult(await Mediator.Send(new DeleteAcademicStaff.Command { AcademicStaffId = academicStaffId }));

        }

    }
}
