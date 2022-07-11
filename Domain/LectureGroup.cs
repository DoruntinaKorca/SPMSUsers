using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LectureGroup
    {
        [Key]
        public int LectureGroupId { get; set; }

        public String GroupName { get; set; }

    //    public ICollection<StudentsLectureGroup> LectureGroups { get; set; } = new List<StudentsLectureGroup>();
    }
}
