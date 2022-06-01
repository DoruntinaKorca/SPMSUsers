using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class AcademicLevel
    {
        [Key]
        public int AcademicLevelId { get; set; }

        [Required]
        public String Name { get; set; }

        public ICollection<AcademicStaff> AcademicStaff { get; set; } = new List<AcademicStaff>();
    }
}
