
using Domain.Exams;

namespace Domain.Users.Students
{
    public class StudentQuestion
    {
        public long StudentId { get; set; }
        public long QuestionId { get; set; }
        public long ExamId { get; set; }
        public string Answer { get; set; }
    }
}
