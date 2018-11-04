using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StudentModel;

namespace StudentRepository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> StudentRepository { get; }
        void Save();
    }
}
