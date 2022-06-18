using Application.DTOs.CityDtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CountryDtos
{
    public class CountryDto
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }
        public List<CityDto> Cities { get; set; }
    }
}
