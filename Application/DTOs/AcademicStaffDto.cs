using Domain;
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

        public AcademicLevelDto AcademicLevel { get; set; }

    }
}
