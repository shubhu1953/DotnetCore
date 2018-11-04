using System.Collections.Generic;

namespace SimpleWebApiWithDocker.Models
{
    public interface IGenericRepository<T>
    {
        void Add(T student);
        void Remove(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}