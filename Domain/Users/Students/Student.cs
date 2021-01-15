using Domain.Common;
using Domain.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users.Students
{
    public class Student:Entity
    {
        public long StudentNum { get; set; }
        public string FullName { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<StudentExam> StudentsExams { get; set; }
        public ICollection<StudentQuestion> StudentQuestion { get; set; }

        public Student()
        {

        }

        public Student(long id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}
