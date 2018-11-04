using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApiWithDocker.Models;

namespace SimpleWebApiWithDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private StudentContext _studentContext;
        public StudentsController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentContext.Students.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetSetudent(int studentId)
        {
            return Ok(_studentContext.Students.FirstOrDefault(t => t.Id == studentId));
        }

        [HttpPost]
        public async Task<IActionResult> PostStudentAsync([FromBody] Student student)
        {
            var originalStudent = _studentContext.Students.FirstOrDefault(t => t.Id == student.Id);

            if (originalStudent != null)
                return BadRequest();

            _studentContext.Students.Add(student);

            await _studentContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutStudentAsync([FromBody] Student student)
        {
            var originalStudent = _studentContext.Students.FirstOrDefault(t => t.Id == student.Id);

            if (originalStudent == null)
                return NotFound();

            originalStudent.Name = student.Name;

            await _studentContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentAsync(int studentId)
        {
            var originalStudent = _studentContext.Students.FirstOrDefault(t => t.Id == studentId);

            if (originalStudent == null)
                return NotFound();

            _studentContext.Students.Remove(originalStudent);

            await _studentContext.SaveChangesAsync();

            return Ok();
        }
    }
}