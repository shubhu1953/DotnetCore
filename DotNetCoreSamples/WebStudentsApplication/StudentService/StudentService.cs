using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentRepository;
using StudentModel;
using System.Threading.Tasks;

namespace StudentService
{
    public class StudentServices : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Student student)
        {
            await _unitOfWork.StudentRepository.Create(student);
        }

        public Task<Student> GetStudentAsync(int studentId)
        {
            return _unitOfWork.StudentRepository.GetById(studentId);
        }

        public List<Student> GetStudents()
        {
            return _unitOfWork.StudentRepository.GetAll().ToList();
        }
    }
}
