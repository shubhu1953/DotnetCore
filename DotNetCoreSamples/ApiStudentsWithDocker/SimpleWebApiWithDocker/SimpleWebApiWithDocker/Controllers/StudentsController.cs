using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using SimpleWebApiWithDocker.Models;

namespace SimpleWebApiWithDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IStudentService studentService;

        public StudentsController(IUnitOfWork unitOfWork, IStudentService studentService)
        {
            this.unitOfWork = unitOfWork;
            this.studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(studentService.GetSetudents());
        }

        [HttpGet("{studentId}")]
        public IActionResult GetSetudent(int studentId)
        {
            return Ok(studentService.GetStudent(studentId));
        }

        [HttpPost]
        public async Task<IActionResult> PostStudentAsync([FromBody] Student student)
        {
            var originalStudent = studentService.GetStudent(student.Id);

            if (originalStudent != null)
                return BadRequest();

            await studentService.AddStudent(student);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutStudentAsync([FromBody] Student student)
        {
            var originalStudent = studentService.GetStudent(student.Id);

            if (originalStudent == null)
                return NotFound();

            originalStudent.Name = student.Name;

            await unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentAsync(int studentId)
        {
            var originalStudent = studentService.GetStudent(studentId);

            if (originalStudent == null)
                return NotFound();

            await studentService.DeleteStudent(studentId);

            return Ok();
        }
    }
}