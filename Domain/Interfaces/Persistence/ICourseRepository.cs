using Domain.Courses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesWithStudentsByTeacherIdAsync(long teacherId);
        Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(long teacherId);
        Course GetCourseWithStudents(long? id);
    }
}
