using Application.Commands.Students;
using Application.DTOs.StudentDtos;
using Application.Queries.Students;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class StudentsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GeneralStudentDto>>> GetAllStudents()
        {
            return await Mediator.Send(new GetAllStudents.Query());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralStudentDto>> GetStudentProfile(Guid id)
        {
            return await Mediator.Send(new GetStudentProfile.Query {StudentId = id });
        }




        [HttpGet("getStudentsForFaculty/{facultyId}")]
        public async Task<ActionResult<List<GeneralStudentDto>>> GetStudentsForFaculty(int facultyId)
        {
            return await Mediator.Send(new GetStudentsForFaculty.Query { FacultyId = facultyId });
        }

        [HttpGet("getStudentForFaculty/{facultyId}/{studentId}")]
        public async Task<ActionResult<GeneralStudentDto>> GetStudentForFaculty(int facultyId, Guid studentId)
        {
            return await Mediator.Send(new GetStudentForFaculty.Query { FacultyId = facultyId,StudentId = studentId });
        }



        [HttpPost("{facultyId}")]
        public async Task<IActionResult> RegisterStudent(RegisterStudentDto registerStudentDto, int facultyId)
        {
            return Ok(await Mediator.Send(new RegisterStudent.Command { RegisterStudentDto = registerStudentDto, FacultyId = facultyId }));
        }

        [HttpPost("addStudentToSpecialization/{studentId}/{specializationId}")]
        public async Task<IActionResult> AddStudentToSpecialization(SpecializationDto specialization, Guid studentId, int specializationId)
        {
            specialization.StudentId = studentId;
            specialization.SpecializationId = specializationId;
            return Ok(await Mediator.Send(new SelectSpecializationForStudent.Command { Specialization = specialization }));
        }


        [HttpPost("addStudentToLectureGroup/{studentId}/{lectureGroupId}")]
        public async Task<IActionResult> AddStudentToLectureGroup(LectureGroupDto lectureGroup, Guid studentId, int lectureGroupId)
        {
            lectureGroup.StudentId = studentId;
            lectureGroup.LectureGroupId = lectureGroupId;
            return Ok(await Mediator.Send(new SelectLectureGroupForStudent.Command { LectureGroup = lectureGroup }));
        }




        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            return Ok(await Mediator.Send(new DeleteStudent.Command { StudentId = studentId }));

        }



        // [HttpPut("{Id}")]

        [HttpPut("{studentId}")]
        public async Task<IActionResult> EditStudent(EditStudentDto student, Guid studentId)
        {

            return Ok(await Mediator.Send(new EditStudent.Command { StudentDto = student, Id = studentId }));
        }
    }
}
