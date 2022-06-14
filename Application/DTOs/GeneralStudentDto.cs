using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GeneralStudentDto
    {
        public Guid StudentId { get; set; }

        public String FirstName { get; set; }

        public String Surname { get; set; }

        public String FileNumber { get; set;}

        public GenerationDto Generation { get;set;}

        public List<int> Faculties { get; set; }

        public List<int> LectureGroups { get; set;}
        
        public List<int> Specializations { get; set;}
    }
}
