using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AcademicStaffDtos
{
    public class AcademicStaffPublishedDto
    {
        public Guid AcademicStaffId { get; set; }

        public String FirstName { get; set; }

        public String Surname { get; set; }

        public String Event { get; set; }
    }
}
