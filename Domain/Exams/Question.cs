using Domain.Common;
using Domain.Users.Students;
using System.Collections.Generic;

namespace Domain.Exams
{
    public class Question : Entity
    {
        public string Text { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<StudentQuestion> StudentsQuestions { get; set; }
        public int QuestionNumInExam { get; set; }
        public double Points { get; set; }
        public long ExamId { get; set; }
    }
}