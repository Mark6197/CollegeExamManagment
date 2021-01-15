using Domain.Courses;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Courses
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDomainDbContext context) :base(context)
        {
        }

        public async Task<IEnumerable<Course>> GetCoursesWithStudentsByTeacherIdAsync(long teacherId)
        {
            return await Context.Courses.Where(c => c.TeacherId == teacherId)
                                        .Include(c=>c.Students)
                                        .ToListAsync();
        }

        public Course GetCourseWithStudents(long? id)
        {
            return  Context.Courses.Where(c => c.Id == id)
                                                 .Include(c => c.Students).FirstOrDefault();
        }

        public AppDomainDbContext Context
        {
            get { return _context as AppDomainDbContext; }
        }

    }
}
