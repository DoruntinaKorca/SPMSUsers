using Application.Commands.AcademicLevel;
using Application.DTOs.AcademicLevelDtos;
using Application.Queries.AcademicLevel;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AcademicLevelsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<AcademicLevelDto>>> GetAllAcademicLevel()
        {
            var academicLevels = await Mediator.Send(new GetAllAcademicLevels.Query());
            return HandleResult(academicLevels);
        }

        [HttpGet("{academicLevelId}")]
        public async Task<ActionResult<AcademicLevelDto>> GetAcademicLevelById(int academicLevelId)
        {
            var academicLevel = await Mediator.Send(new GetAcademicLevelById.Query { AcademicLevelId = academicLevelId });
            return HandleResult(academicLevel);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAcademicLevel(AcademicLevel academicLevel)
        {

            return HandleResult(await Mediator.Send(new AddNewAcademicLevel.Command { AcademicLevel = academicLevel }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicLevel(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteAcademicLevel.Command { AcademicLevelId = id }));
        }

        [HttpPut("{academicLevelId}")]
        public async Task<IActionResult> EditAcademicLevel(AcademicLevelDto academicLevel, int academicLevelId)
        {
            academicLevel.AcademicLevelId = academicLevelId;

            return HandleResult(await Mediator.Send(new EditAcademicLevel.Command { AcademicLevel = academicLevel, AcademicLevelId = academicLevelId }));
        }
    }
}