using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AcademicStaffDtos
{
    public class EditAcademicStaffDto
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string ParentName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AddressDetails { get; set; }

        public string ProfilePictureURL { get; set; }

        public string Gender { get; set; }

        public int CityId { get; set; }

        public int PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public int AcademicLevelId { get; set; }
    }
}
