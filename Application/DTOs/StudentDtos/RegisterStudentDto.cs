using Application.DTOs.UserDtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.StudentDtos
{
    public class RegisterStudentDto
    {
        public Guid StudentId { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string ParentName { get; set; }

        public string Surname { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string AddressDetails { get; set; }

        public int CityId { get; set; }

       // public string ProfilePictureURL { get; set; }

        public string Gender { get; set; }


        public int PersonalNumber { get; set; }


        public DateTime DateRegistered { get; set; }


        public int FileNumber { get; set; }

        public string Password { get; set; }

       // public Guid Role { get; set; }


        // public int FacultyId { get; set; }
    }
}
