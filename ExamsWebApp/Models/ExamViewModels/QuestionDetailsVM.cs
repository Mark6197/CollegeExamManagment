using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.ExamViewModels
{
    public class QuestionDetailsVM
    {
        public string Text { get; set; }
        public IEnumerable<AnswerDetailsVM> Answers { get; set; }
        public int QuestionNumInExam { get; set; }
        public double Points { get; set; }
        public long ExamId { get; set; }

        public QuestionDetailsVM()
        {
            Answers = new List<AnswerDetailsVM>();
        }
    }
}
