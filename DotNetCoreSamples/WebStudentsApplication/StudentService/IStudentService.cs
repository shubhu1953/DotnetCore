using StudentRepository;
using System;
using System.Collections.Generic;
using System.Text;
using StudentModel;
using System.Threading.Tasks;

namespace StudentService
{
    public interface IStudentService
    {
        Task<Student> GetStudentAsync(int studentId);
        List<Student> GetStudents();
        Task Create(Student student);
    }
}
