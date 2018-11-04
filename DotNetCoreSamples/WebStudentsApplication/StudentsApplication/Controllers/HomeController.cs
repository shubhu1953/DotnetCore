using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsApplication.Models;
using StudentModel;
using StudentService;

namespace StudentsApplication.Controllers
{
    public class HomeController : Controller
    {
        public IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Students()
        {
            var newStudents = _studentService.GetStudents();
            return View(newStudents);
        }
        //[Route("Home/StudentInformation/{studentId}")]
        public async Task<IActionResult> StudentInformation([Bind(Prefix = "id")] int studentId)
        {
            var student =
                await _studentService
                .GetStudentAsync(studentId);

            return Content("The student name is:" + student.Name);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await _studentService.Create(student);

            return RedirectToAction("Students");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
