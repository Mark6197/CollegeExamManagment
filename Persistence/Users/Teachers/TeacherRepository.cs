using Domain.Interfaces.Persistence;
using Domain.Users.Teachers;
using Persistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Users.Teachers
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDomainDbContext context) : base(context)
        {
        }


    }
}
