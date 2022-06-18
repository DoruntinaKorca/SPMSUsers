using Application.DTOs.CityCategoryDtos;
using Application.Queries.CityCategories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CityCategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<CityCategoryDto>>> GetAllCityCategories()
        {
            return await Mediator.Send(new GetAllCityCategories.Query());
        }


        [HttpGet("{cityCategoryId}")]
        public async Task<ActionResult<CityCategoryDto>> GetCityCategoryById(int cityCategoryId)
        {
            return await Mediator.Send(new GetCityCategoryById.Query { CityCategoryId = cityCategoryId });
        }
    }
}
