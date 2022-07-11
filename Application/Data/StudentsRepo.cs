using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public class StudentsRepo : IStudentsRepo
    {
        private readonly UsersContext _context;

        public StudentsRepo(UsersContext context)
        {
            _context = context;
        }

        public void CreateLectureGroup(LectureGroup lectureGroup)
        {
            throw new NotImplementedException();
        }

        public bool LectureGroupExists(int lectureGroupId)
        {
            throw new NotImplementedException();
        }

            public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
