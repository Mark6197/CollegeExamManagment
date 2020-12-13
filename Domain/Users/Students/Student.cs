using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users.Students
{
    public class Student
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<StudentsCourses> StudentsCourses { get; set; }

    }
}
