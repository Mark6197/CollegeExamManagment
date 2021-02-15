using Domain.Courses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesWithStudentsAsync(long teacherId);
        Task<IEnumerable<Course>> GetCoursesAsync(long teacherId);
        Task<Course> GetCourseWithStudentsAndExamsAsync(long id);
        Task<Course> GetCourseWithFullExamsAsync(long id);
    }
}
