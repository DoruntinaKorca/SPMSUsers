using Application.DTOs.GenerationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.StudentDtos
{
    public class GeneralStudentDto
    {
        public Guid StudentId { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string FileNumber { get; set; }

        public GenerationDto Generation { get; set; }

        public List<int> Faculties { get; set; }

        public List<int> LectureGroups { get; set; }

        public List<int> Specializations { get; set; }
    }
}
