using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        Task<int> SaveAsync();
    }
}
