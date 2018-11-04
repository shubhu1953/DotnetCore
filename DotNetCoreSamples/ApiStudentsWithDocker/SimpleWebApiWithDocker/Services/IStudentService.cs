using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IStudentService
    {
        Task AddStudent(Student student);
        Task DeleteStudent(int studentId);
        Student GetStudent(int studentId);
        IEnumerable<Student> GetSetudents();
    }
}