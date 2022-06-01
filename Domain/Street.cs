using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Index(nameof(StreetName), IsUnique = true)]
    public class Street
    {
        [Key]
        public int StreetId { get; set; }

        [Required]
        public String StreetName { get; set; }

        public int StreetNumber { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

        public int CityId { get; set; }

        public City City { get; set; } 
    }
}
