using Domain.Common;
using Domain.Exams;
using Domain.Users.Students;
using Domain.Users.Teachers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Courses
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ICollection<Student> Students { get; set; }
        public IList<AssignedExam> AssignedExams { get; set; }
        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public Course()
        {
            Students = new List<Student>();
            AssignedExams = new List<AssignedExam>();
        }
    }
}
