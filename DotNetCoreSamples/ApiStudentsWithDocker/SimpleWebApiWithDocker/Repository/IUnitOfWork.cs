using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SimpleWebApiWithDocker.Models
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        Task<int> SaveChangesAsync();
    }
}