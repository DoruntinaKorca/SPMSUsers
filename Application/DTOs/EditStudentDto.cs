using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EditStudentDto
    {
    //    public Guid StudentId { get; set; }
    //    public virtual User User { get; set; }

        public int LectureGroupId { get; set; }


        public int GenerationId { get; set; }
   //     public Generation Generation { get; set; }

        public int FileNumber { get; set; }
    //    public ICollection<StudentsSpecializations> Specializations { get; set; } = new List<StudentsSpecializations>();

   //     public ICollection<StudentsGroups> LectureGroups { get; set; } = new List<StudentsGroups>();


    }
}
