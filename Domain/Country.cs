using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public String CountryName { get; set; }


        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
