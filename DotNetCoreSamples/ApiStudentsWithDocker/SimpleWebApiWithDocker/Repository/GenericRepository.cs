using System.Collections.Generic;
using System.Linq;
using Models;

namespace SimpleWebApiWithDocker.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly StudentContext unitOfWork;

        public GenericRepository(StudentContext unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(T student)
        {
            unitOfWork.Set<T>().Add(student);
        }

        public IEnumerable<T> GetAll()
        {
            return unitOfWork.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return unitOfWork.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public void Remove(T item)
        {
            unitOfWork.Set<T>().Remove(item);
        }
    }
}