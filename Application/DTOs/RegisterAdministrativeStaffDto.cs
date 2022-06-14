using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RegisterAdministrativeStaffDto
    {
        public Guid AdministrativeStaffId { get; set; }

        public String FirstName { get; set; }

        public String Email { get; set; }

        public String ParentName { get; set; }

        public String Surname { get; set; }


        public DateTime DateOfBirth { get; set; }

        public String AddressDetails { get; set; }

        public int CityId { get; set; }

        public String ProfilePictureURL { get; set; }

        public String Gender { get; set; }


        public int PersonalNumber { get; set; }


        public DateTime DateRegistered { get; set; }


        public String Password { get; set; }
    }
}
