using Application.Commands.AdministrativeStaff;
using Application.DTOs.AdministrativeStaffDtos;
using Application.Queries.AdministrativeStaff;
using Microsoft.AspNetCore.Http;
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
            var administrativeStaff= await Mediator.Send(new GetAllAdministrativeStaff.Query());
            return HandleResult(administrativeStaff);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdministrativeStaffDto>> GetAdministrativeStaffProfile(Guid id)
        {
            var profile =  await Mediator.Send(new GetAdministrativeStaffProfile.Query { AdministrativeStaffId = id });
            return HandleResult(profile);
        }

        [HttpPost("{facultyId}")]
        public async Task<IActionResult> RegisterAdministrativeStaff([FromForm] RegisterAdministrativeStaffDto administrativeStaff, [FromForm] int facultyId, [FromForm] IFormFile file)
        {
            return HandleResult(await Mediator.Send(new RegisterAdministrativeStaff.Command { RegisterAdministrativeStaffDto = administrativeStaff, FacultyId = facultyId, File= file }));
        }

        [HttpPut("{administrativeStaffId}")]
        public async Task<IActionResult> EditAdministrativeStaff(EditAdministrativeStaffDto administrativeStaff, Guid administrativeStaffId)
        {

            return HandleResult(await Mediator.Send(new EditAdministrativeStaff
                .Command { AdministrativeStaffDto = administrativeStaff, Id = administrativeStaffId }));
        }


        [HttpDelete("{adminsitrativeStaffId}")]
        public async Task<IActionResult> DeleteAdministrativeStaff(Guid adminsitrativeStaffId)
        {
            return HandleResult(await Mediator.Send(new DeleteAdministrativeStaff.Command { AdministrativeStaffId = adminsitrativeStaffId }));

        }
    }
}
