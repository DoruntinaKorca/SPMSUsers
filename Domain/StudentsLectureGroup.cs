using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StudentsLectureGroup
    {
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public int LectureGroupId { get; set; }

       // public LectureGroup LectureGroup { get; set; }
    }
}
