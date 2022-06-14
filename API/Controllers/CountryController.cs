using Application.DTOs;
using Application.Queries.Countries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AddressController : BaseApiController
    {

        [HttpGet("getAllCountries")]
        public async Task<ActionResult<List<CountryDto>>> GetAllCountries()
        {
            return await Mediator.Send(new GetAllCountries.Query());
        }


        [HttpGet("getCountry/{countryId}")]
        public async Task<ActionResult<CountryDto>> GetCountryById(int countryId)
        {
            return await Mediator.Send(new GetCountryById.Query { CountryId=countryId});
        }
    }
}
