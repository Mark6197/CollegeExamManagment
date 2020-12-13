using Domain.Users.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Persistence
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
