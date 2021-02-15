using Domain.Courses;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Courses
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDomainDbContext context) :base(context)
        {
        }

        public async Task<IEnumerable<Course>> GetCoursesWithStudentsAsync(long teacherId)
        {
            return await Context.Courses.Where(c => c.TeacherId == teacherId)
                                        .Include(c=>c.Students)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync(long teacherId)
        {
            return await Context.Courses.Where(c => c.TeacherId == teacherId)
                                        .ToListAsync();
        }

        public async Task<Course> GetCourseWithStudentsAndExamsAsync(long id)
        {
            return await Context.Courses.Where(c => c.Id == id)
                                                 .Include(c => c.Students)
                                                 .Include(c => c.AssignedExams)
                                                 .FirstOrDefaultAsync();
        }

        public async Task<Course> GetCourseWithFullExamsAsync(long id)
        {
            return await Context.Courses.Where(c => c.Id == id)
                                                 .Include(c => c.AssignedExams).ThenInclude(e=>e.Questions).ThenInclude(q=>q.Answers).FirstOrDefaultAsync();
        }

        public AppDomainDbContext Context
        {
            get { return _context as AppDomainDbContext; }
        }

    }
}
