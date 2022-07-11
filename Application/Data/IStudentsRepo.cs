using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface IStudentsRepo
    {
        bool LectureGroupExists(int lectureGroupId);

        void CreateLectureGroup(LectureGroup lectureGroup);

        bool SaveChanges();
    }
}
