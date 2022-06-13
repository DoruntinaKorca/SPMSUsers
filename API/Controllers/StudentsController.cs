using Application.Commands.Students;
using Application.DTOs;
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
        public async Task<ActionResult<List<StudentDto>>> GetAllStudents()
        {
            return await Mediator.Send(new GetAllStudents.Query());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentProfile(Guid id)
        {
            return await Mediator.Send(new GetStudentProfile.Query {StudentId = id });
        }




        [HttpGet("getStudentsForFaculty/{facultyId}")]
        public async Task<ActionResult<List<StudentDto>>> GetStudentsForFaculty(int facultyId)
        {
            return await Mediator.Send(new GetStudentsForFaculty.Query { FacultyId = facultyId });
        }



        [HttpPost("{facultyId}")]
        public async Task<IActionResult> RegisterStudent(RegisterStudentDto registerStudentDto, int facultyId)
        {
            return Ok(await Mediator.Send(new RegisterStudent.Command { RegisterStudentDto = registerStudentDto, FacultyId = facultyId }));
        }




        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            return Ok(await Mediator.Send(new DeleteStudent.Command { StudentId = studentId }));

        }



       // [HttpPut("{Id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(EditStudentDto student, Guid id)
        {
            return Ok(await Mediator.Send(new EditStudent.Command { editStudentDto = student , Id = id}));
        }
    }
}
