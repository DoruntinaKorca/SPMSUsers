using Application.Commands.Countries;
using Application.DTOs.CityDtos;
using Application.DTOs.CountryDtos;
using Application.Queries.Cities;
using Application.Queries.Countries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CountriesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<CountryWOCityDto>>> GetAllCountries()
        {
            var countries = await Mediator.Send(new GetAllCountries.Query());
            return HandleResult(countries);
        }


        [HttpGet("getCitiesForCountry/{countryId}")]
        public async Task<ActionResult<List<CityDto>>> GetCitiesForCountry(int countryId)
        {
            var citiesForCountry =  await Mediator.Send(new GetAllCitiesForCountry.Query { CountryId = countryId});
            return HandleResult(citiesForCountry);
        }


        [HttpGet("{countryId}")]
        public async Task<ActionResult<CountryDto>> GetCountryById(int countryId)
        {
            var country = await Mediator.Send(new GetCountryById.Query { CountryId=countryId});
            return HandleResult(country);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewCountry(AddCountryDto country)
        {
            return HandleResult(await Mediator.Send(new AddNewCountry.Command { CountryDto = country }));
        }

        [HttpPut("{countryId}")]
        public async Task<IActionResult> EditCountry(EditCountryDto country, int countryId)
        {

            return HandleResult(await Mediator.Send(new EditCountry.Command { CountryDto = country, CountryId = countryId }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCountry.Command { CountryId = id }));
        }
    }
}
