using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.StudentDtos
{
    public class EditStudentDto
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

        public string FileNumber { get; set; }

        // public GenerationDto Generation { get; set; }

        //  public List<int> Faculties { get; set; }

        //  public List<int> LectureGroups { get; set; }

        //  public List<int> Specializations { get; set; }
    }
}
