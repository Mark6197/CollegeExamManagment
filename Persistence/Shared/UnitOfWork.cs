using Domain.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDomainDbContext _context;

        public UnitOfWork(AppDomainDbContext context,IStudentRepository studentRepository,
            ITeacherRepository teacherRepository,ICourseRepository courseRepository,
            IExamRepository examRepository)
        {
            _context = context;
            Students = studentRepository;
            Teachers = teacherRepository;
            Courses = courseRepository;
            Exams = examRepository;
        }

        public IStudentRepository Students { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IExamRepository Exams { get; private set; }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
