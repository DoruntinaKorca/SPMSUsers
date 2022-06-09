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
    }
}
