﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CityDtos
{
    public class AddCityDto
    {
        //   public int CityId { get; set; }


        public string CityName { get; set; }

        public int ZIPCode { get; set; }

        public int CategoryId { get; set; }

        public int CountryId { get; set; }
    }
}
