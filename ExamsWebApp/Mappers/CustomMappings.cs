using Domain.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Mappers
{
    public class CustomMappings
    {
        public static void Map_Exam_To_AssignedExam(Exam exam, AssignedExam assignedExam)
        {
            assignedExam.AutoPointsCalculation = exam.AutoPointsCalculation;
            assignedExam.Duration = exam.Duration;
            assignedExam.Title = exam.Title;
            if (exam.Questions.Count > 0)
            {
                foreach (var q in exam.Questions)
                {
                    Question question = new Question();
                    question.Text = q.Text;
                    question.QuestionNumInExam = q.QuestionNumInExam;
                    question.Points = q.Points;
                    if (q.Answers.Count > 0)
                    {
                        foreach (var a in q.Answers)
                        {
                            Answer answer = new Answer();
                            answer.Text = a.Text;
                            answer.AnswerNumInQuestion = a.AnswerNumInQuestion;
                            answer.IsCorrect = a.IsCorrect;
                            question.Answers.Add(answer);
                        }
                    }
                    assignedExam.Questions.Add(question);
                }
            }
        }
    }
}
