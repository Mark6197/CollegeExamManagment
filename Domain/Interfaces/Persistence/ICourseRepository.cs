using Domain.Courses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface ICourseRepository : IRepository<Course>
    {
         Task<IEnumerable<Course>> GetCoursesWithStudentsByTeacherIdAsync(long teacherId);
        Course GetCourseWithStudents(long? id);
    }
}
