using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Exams
{
    public enum ExamType
    {
        Exam=1,
        AssignedExam=2
    }

    public class Exam : Entity
    {
        public string Title { get; set; }
        public IList<Question> Questions { get; set; }
        public long TeacherId { get; set; }
        public ExamType ExamType { get; set; }
        public TimeSpan? Duration { get; set; }
        public bool AutoPointsCalculation { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
        }
    }
}
