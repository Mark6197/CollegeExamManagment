﻿namespace ExamsWebApp.Models.ExamViewModels
{
    public class AnswerDetailsVM
    {
        public string Text { get; set; }
        public int AnswerNumInQuestion { get; set; }
        public long QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}