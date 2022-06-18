using Application.DTOs.AcademicLevelDtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AcademicStaffDtos
{
    public class AcademicStaffDto
    {
        public Guid AcademicStaffId { get; set; }

        // public virtual User User { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public AcademicLevelDto AcademicLevel { get; set; }

    }
}
