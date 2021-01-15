using Domain.Common;
using Domain.Courses;
using Domain.Exams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users.Teachers
{
    public class Teacher : Entity
    {
        public long TeacherNum { get; set; }
        public string FullName { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Exam> Exams { get; set; }

        protected Teacher()
        {

        }
        public Teacher(long id, string fullName) :this()
        {
            Id = id;
            FullName = fullName;
        }
        public Teacher(long id, string fullName, string experience, string skills) :this()
        {
            Id = id;
            FullName = fullName;
            Experience = experience;
            Skills = skills;
        }
        

    }
}
