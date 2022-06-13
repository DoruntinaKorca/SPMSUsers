using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
    {
        //[Key]
        public Guid StudentId { get; set; }
        public virtual User User { get; set; }

        public int GenerationId { get; set; }
        public Generation Generation { get; set; }

        public int FileNumber { get; set; }
        public ICollection<StudentsSpecialization> Specializations { get; set; } = new List<StudentsSpecialization>();

        public ICollection<StudentsLectureGroup> LectureGroups { get; set; } = new List<StudentsLectureGroup>();

     

    }
}
