using Domain.Common;

namespace Domain.Exams
{
    public class Answer:Entity
    {

            public string Text { get; set; }
            public int AnswerNumInQuestion { get; set; }
            public long QuestionId { get; set; }
            public bool IsCorrect { get; set; }
        
    }
}