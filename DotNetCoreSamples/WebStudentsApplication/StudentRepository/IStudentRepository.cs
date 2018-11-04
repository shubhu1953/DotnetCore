using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;

namespace StudentRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        
    }
}
