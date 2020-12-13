using Domain.Common;
using Domain.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users.Teachers
{
    public class Teacher : Entity
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
