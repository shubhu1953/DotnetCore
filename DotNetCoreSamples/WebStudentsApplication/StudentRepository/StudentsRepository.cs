using System;
using System.Collections.Generic;
using System.Text;
using StudentModel;

namespace StudentRepository
{
    public class StudentsRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentsRepository(StudentDbContext dbContext)
        : base(dbContext)
        {

        }
    }
}
