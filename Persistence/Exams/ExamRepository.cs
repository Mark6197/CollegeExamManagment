using Domain.Exams;
using Domain.Interfaces.Persistence;
using Persistence.Shared;


namespace Persistence.Exams
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(AppDomainDbContext context) : base(context)
        {
        }

        public AppDomainDbContext Context
        {
            get { return _context as AppDomainDbContext; }
        }
    }
}
