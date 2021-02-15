using Domain.Courses;
using Domain.Users.Students;
using System;
using System.Collections.Generic;


namespace Domain.Exams
{
    public class AssignedExam:Exam
    {
        public long CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<StudentExam> StudentsExams { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public AssignedExam():base()
        {

        }
    }
}
