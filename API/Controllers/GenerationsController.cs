using Application.Commands.Generations;
using Application.DTOs.GenerationDtos;
using Application.DTOs.StudentDtos;
using Application.Queries.Generations;
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
            var students= await Mediator
                .Send(new GetStudentsForGeneration.Query { GenerationId = generationId });
            return HandleResult(students);
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneralGenerationDto>>> GetAllGenerations()
        {
            var generations = await Mediator.Send(new GetAllGenerations.Query());
            return HandleResult(generations);
        }


        [HttpGet("{generationId}")]
        public async Task<ActionResult<GeneralGenerationDto>> GetGenerationById(int generationId)
        {
            var generation = await Mediator.Send(new GetGenerationById.Query { GenerationId = generationId });
            return HandleResult(generation);
        }

        [HttpPut("{generationId}")]
        public async Task<IActionResult> EditGeneration(GenerationDto generation, int generationId)
        {
            
            return HandleResult(await Mediator.Send(new EditGeneration.Command { GenerationDto = generation, GenerationId = generationId }));
        }


        [HttpPost]
        public async Task<IActionResult> AddNewGeneration(GenerationDto generation)
        {
            return HandleResult(await Mediator.Send(new AddNewGeneration.Command { GenerationDto = generation }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneration(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteGeneration.Command { GenerationId = id }));
        }

    }
}
