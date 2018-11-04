using Models;

namespace SimpleWebApiWithDocker.Models
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}