using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CityCategory
    {

        [Key]
        public int CityCategoryId { get; set; }

        public String CategoryName { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
