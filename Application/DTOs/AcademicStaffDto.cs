using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AcademicStaffDto
    {
        public Guid AcademicStaffId { get; set; }

        // public virtual User User { get; set; }
        public String FirstName { get; set; }
        public String Surname { get; set; }

        public int AcademicLevelId { get; set; }
        public String AcademicLevel { get; set; }
    }
}
