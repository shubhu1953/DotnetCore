using Microsoft.EntityFrameworkCore;
using StudentModel;

namespace StudentRepository
{
    public class StudentDbContext :  DbContext
    {
        DbSet<Student> StudentRepository { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentMap());
        }

    }
}
