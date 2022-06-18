using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AcademicStaffDtos
{
    public class RegisterAcademicStaffDto
    {
        public Guid AcademicStaffId { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string ParentName { get; set; }

        public string Surname { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string AddressDetails { get; set; }

        public int CityId { get; set; }

        public string ProfilePictureURL { get; set; }

        public string Gender { get; set; }


        public int PersonalNumber { get; set; }


        public DateTime DateRegistered { get; set; }


        public int AcademicLevelId { get; set; }

        public string Password { get; set; }
    }
}
