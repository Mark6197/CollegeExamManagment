using Domain.Interfaces.Persistence;
using Domain.Users.Students;
using Persistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Users.Students
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDomainDbContext context) : base(context)
        {
        }
    }
}
