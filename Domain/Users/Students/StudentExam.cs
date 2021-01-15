
using Domain.Exams;

namespace Domain.Users.Students
{
    public class StudentExam
    {
        public long StudentId { get; set; }
        public long ExamId { get; set; }
        public bool IsCompleted { get; set; }
        public int? Grade { get; set; }

    }
}
