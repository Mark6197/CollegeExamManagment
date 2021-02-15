using Domain.Exams;
using Domain.Interfaces.Persistence;
using Persistence.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Exams
{
    public class AssignedExamRepository : Repository<AssignedExam>, IAssignedExamRepository
    {
        public AssignedExamRepository(AppDomainDbContext context) : base(context)
        {
        }


        public AppDomainDbContext Context
        {
            get { return _context as AppDomainDbContext; }
        }
    }
}
