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
            var cityCategories = await Mediator.Send(new GetAllCityCategories.Query());
            return HandleResult(cityCategories);
        }


        [HttpGet("{cityCategoryId}")]
        public async Task<ActionResult<CityCategoryDto>> GetCityCategoryById(int cityCategoryId)
        {
            var cityCategory =  await Mediator.Send(new GetCityCategoryById.Query { CityCategoryId = cityCategoryId });
            return HandleResult(cityCategory);
        }
    }
}
