using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.ExamViewModels
{
    public class CreateQuestionVM
    {
        [Required(ErrorMessage = "Question's text is required")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Question's text must be minimum of 5 and maximum 500 characters")]
        public string Text { get; set; }
        public List<CreateAnswerVM> Answers { get; set; }

        [Range(0,100)]
        public double Points { get; set; }

        public CreateQuestionVM()
        {
            Answers = new List<CreateAnswerVM>();
        }
    }
}
