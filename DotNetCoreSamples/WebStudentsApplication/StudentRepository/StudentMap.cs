using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentModel;

namespace StudentRepository
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnType("nvarchar(200)").IsRequired();
        }
    }
}
