using Application.Commands.Cities;
using Application.DTOs.CityDtos;
using Application.Queries.Cities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<CityDto>>> GetAllCities()
        {
            return HandleResult(await Mediator.Send(new GetAllCities.Query()));
        }


        [HttpGet("{cityId}")]
        public async Task<ActionResult<CityDto>> getCityById(int cityId)
        {
            return HandleResult(await Mediator.Send(new GetCityById.Query { CityId = cityId}));
        }


        [HttpPost("{countryId}/{categoryId}")]
        public async Task<IActionResult> AddNewCity(AddCityDto cityDto, int countryId, int categoryId)
        {
            cityDto.CountryId = countryId;
            cityDto.CategoryId = categoryId;
            return HandleResult(await Mediator.Send(new AddNewCity.Command { CityDto = cityDto, CountryId = countryId, CityCategoryId = categoryId}));
        }

        [HttpPut("{cityId}")]
        public async Task<IActionResult> EditCity(CityDto city, int cityId)
        {

            return HandleResult(await Mediator.Send(new EditCity.Command { CityDto = city, CityId = cityId }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCity.Command { CityId = id }));
        }
    }
}
