using Application.Commands.Students;
using Application.DTOs.StudentDtos;
using Application.Queries.Students;
using Domain;
using Microsoft.AspNetCore.Http;
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
            var students= await Mediator.Send(new GetAllStudents.Query());

            return HandleResult(students);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralStudentDto>> GetStudentProfile(Guid id)
        {
            var profile = await Mediator.Send(new GetStudentProfile.Query {StudentId = id });

            return HandleResult(profile);
        }




        [HttpGet("getStudentsForFaculty/{facultyId}")]
        public async Task<ActionResult<List<GeneralStudentDto>>> GetStudentsForFaculty(int facultyId)
        {
            var students = await Mediator.Send(new GetStudentsForFaculty.Query { FacultyId = facultyId });
            return HandleResult(students);
        }

        [HttpGet("getStudentForFaculty/{facultyId}/{studentId}")]
        public async Task<ActionResult<GeneralStudentDto>> GetStudentForFaculty(int facultyId, Guid studentId)
        {
            var student = await Mediator.Send(new GetStudentForFaculty.Query { FacultyId = facultyId,StudentId = studentId });
            return HandleResult(student);
        }



        [HttpPost("{facultyId}")]
        public async Task<IActionResult> RegisterStudent([FromForm]RegisterStudentDto registerStudentDto, [FromForm]int facultyId, [FromForm]IFormFile file)
        {
            return HandleResult(await Mediator.Send(new RegisterStudent.Command { RegisterStudentDto = registerStudentDto, FacultyId = facultyId, File=file}));
        }

        [HttpPost("addStudentToSpecialization/{studentId}/{specializationId}")]
        public async Task<IActionResult> AddStudentToSpecialization(SpecializationDto specialization, Guid studentId, int specializationId)
        {
            specialization.StudentId = studentId;
            specialization.SpecializationId = specializationId;
            return HandleResult(await Mediator.Send(new SelectSpecializationForStudent.Command { Specialization = specialization }));
        }


        [HttpPost("addStudentToLectureGroup/{studentId}/{lectureGroupId}")]
        public async Task<IActionResult> AddStudentToLectureGroup(LectureGroupDto lectureGroup, Guid studentId, int lectureGroupId)
        {
            lectureGroup.StudentId = studentId;
            lectureGroup.LectureGroupId = lectureGroupId;
            return HandleResult(await Mediator.Send(new SelectLectureGroupForStudent.Command { LectureGroup = lectureGroup }));
        }




        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            return HandleResult(await Mediator.Send(new DeleteStudent.Command { StudentId = studentId }));

        }



        // [HttpPut("{Id}")]

        [HttpPut("{studentId}")]
        public async Task<IActionResult> EditStudent([FromForm]EditStudentDto student, Guid studentId)
        {

            return HandleResult(await Mediator.Send(new EditStudent.Command { StudentDto = student, Id = studentId }));
        }
    }
}
