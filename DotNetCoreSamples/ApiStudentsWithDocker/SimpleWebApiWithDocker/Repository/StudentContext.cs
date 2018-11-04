using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApiWithDocker.Models
{
    public class StudentContext : DbContext, IUnitOfWork
    {
        private DbSet<Student> StudentsDbSet { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public IStudentRepository Students => new StudentRepository(this);

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}