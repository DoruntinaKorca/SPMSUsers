using Application.Commands.AdministrativeStaff;
using Application.DTOs;
using Application.Queries.AdministrativeStaff;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AdministrativeStaffController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<AdministrativeStaffDto>>> GetAllAdministrativeStaff()
        {
            return await Mediator.Send(new GetAllAdministrativeStaff.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdministrativeStaffDto>> GetAdministrativeStaffProfile(Guid id)
        {
            return await Mediator.Send(new GetAdministrativeStaffProfile.Query { AdministrativeStaffId = id });
        }

        [HttpPost("{facultyId}")]
        public async Task<IActionResult> RegisterAdministrativeStaff(RegisterAdministrativeStaffDto administrativeStaff, int facultyId)
        {
            return Ok(await Mediator.Send(new RegisterAdministrativeStaff.Command { RegisterAdministrativeStaffDto = administrativeStaff, FacultyId = facultyId }));
        }


        [HttpDelete("{adminsitrativeStaffId}")]
        public async Task<IActionResult> DeleteAdministrativeStaff(Guid adminsitrativeStaffId)
        {
            return Ok(await Mediator.Send(new DeleteAdministrativeStaff.Command { AdministrativeStaffId = adminsitrativeStaffId }));

        }
    }
}
