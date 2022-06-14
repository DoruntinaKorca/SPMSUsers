using Application.Commands.Generations;
using Application.DTOs;
using Application.Queries.Students;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class GenerationsController : BaseApiController
    {

        [HttpGet("getStudentsForGeneration/{generationId}")]
        public async Task<ActionResult<List<GeneralStudentDto>>> GetStudentsForGeneration(int generationId)
        {
            return await Mediator.Send(new GetStudentsForGeneration.Query { GenerationId = generationId });
        }


        [HttpPost]
        public async Task<IActionResult> AddNewGeneration(GenerationDto generation)
        {
            return Ok(await Mediator.Send(new AddNewGeneration.Command { GenerationDto = generation }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneration(int id)
        {
            return Ok(await Mediator.Send(new DeleteGeneration.Command { GenerationId = id }));
        }

    }
}
