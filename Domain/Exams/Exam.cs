using Domain.Common;
using Domain.Users.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Exams
{
    public class Exam : Entity
    {
        public string Title { get; set; }

        public IList<Question> Questions { get; set; }

        public long? CourseId { get; set; }

        public ICollection<StudentExam> StudentsExams { get; set; }

        public long TeacherId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public TimeSpan? Duration { get; set; }

        public bool AutoPointsCalculation { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
        }
    }
}
