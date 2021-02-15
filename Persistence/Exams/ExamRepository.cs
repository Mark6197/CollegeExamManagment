using Domain.Exams;
using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Exams
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(AppDomainDbContext context) : base(context)
        {
        }

        public async Task<Exam> GetNotAssignedFullExamAsync(long examId)
        {
            return await Context.Exams.Where(e=>e.ExamType==ExamType.Exam && e.Id == examId)
                                      .Include(e=>e.Questions)
                                      .ThenInclude(q=>q.Answers)
                                      .FirstOrDefaultAsync();
        }

        public async Task<Exam> GetExamWithQuestionsAndAnswerAsync(long examId)
        {
            return await Context.Exams.Where(e => e.Id == examId)
                                      .Include(e => e.Questions)
                                      .ThenInclude(q => q.Answers)
                                      .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exam>> GetNotAssignedExamsByTeacherAsync(long teacherId)
        {
            return await Context.Exams.Where(e =>e.ExamType==ExamType.Exam && e.TeacherId == teacherId)
                                        .ToListAsync();
        }

        public IEnumerable<Exam> GetAllExamsWithCoursesByTeacher(long teacherId)
        {
            return  Context.Exams.Include(e=>(e as AssignedExam).Course);
            //return  Context.Exams.OfType<AssignedExam>().Include(a=>a.Course).AsEnumerable().Concat<Exam>(Context.Exams.OfType<Exam>());
        }
        //public async Task<IEnumerable<Exam>> GetAllExamsByTeacher(long teacherId)
        //{
        //    return await Context.Exams.Where(e=> e.TeacherId == teacherId).ToListAsync();
        //}

        public AppDomainDbContext Context
        {
            get { return _context as AppDomainDbContext; }
        }
    }
}
