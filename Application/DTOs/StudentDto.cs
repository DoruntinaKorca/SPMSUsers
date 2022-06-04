﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        //public virtual User User { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }
        public int LectureGroupId { get; set; }


        public int GenerationId { get; set; }
        public String Generation { get; set; }


        public int SpecializationId { get; set; }
    }
}