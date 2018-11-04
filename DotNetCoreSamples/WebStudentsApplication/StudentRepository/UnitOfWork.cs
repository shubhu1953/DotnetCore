using System;
using System.Collections.Generic;
using System.Text;
using StudentModel;

namespace StudentRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDbContext _studentContext;

        public UnitOfWork(StudentDbContext studentDbContext)
        {
            _studentContext = studentDbContext;
        }

        public IGenericRepository<Student> StudentRepository => new StudentsRepository(_studentContext);

        public void Save()
        {
            _studentContext.SaveChanges();
        }
    }
}
