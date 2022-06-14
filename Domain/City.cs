using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        public String CityName { get; set; }

        public int ZIPCode { get; set; }

        public int CategoryId { get; set; }

        public CityCategory CityCategory { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
