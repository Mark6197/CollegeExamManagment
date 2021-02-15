using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.ExamViewModels
{
    public class CreateAnswerVM
    {
        [Required(ErrorMessage = "Answer's text is required")]
        [StringLength(500, ErrorMessage = "Answer's text must be maximum 500 characters")]
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

    }
}
