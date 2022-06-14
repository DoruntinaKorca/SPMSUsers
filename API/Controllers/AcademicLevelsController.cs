using Application.DTOs;
using Application.Queries.AcademicLevel;
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
            return await Mediator.Send(new GetAllAcademicLevels.Query());
        }
    }
}
