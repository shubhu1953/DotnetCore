using Models;
using SimpleWebApiWithDocker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddStudent(Student student)
        {
            unitOfWork.Students.Add(student);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteStudent(int studentId)
        {
            var originalStudent = GetStudent(studentId);

            if (originalStudent == null)
                return;

            unitOfWork.Students.Remove(originalStudent);

            await unitOfWork.SaveChangesAsync();
        }

        public Student GetStudent(int studentId)
        {
            return unitOfWork.Students.GetById(studentId);
        }

        public IEnumerable<Student> GetSetudents()
        {
            return unitOfWork.Students.GetAll();
        }
    }
}