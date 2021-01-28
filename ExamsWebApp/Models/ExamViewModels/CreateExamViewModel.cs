using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ExamsWebApp.Models.ExamViewModels
{
    public class CreateExamViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Title must be minimum of 2 and maximum 1000 characters")]
        [BindProperty]
        public string Title { get; set; }

        public List<CreateQuestionViewModel> Questions { get; set; }

        [Display(Name = "Course")]
        public long? CourseId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter the starting date")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter the ending date")]
        [Display(Name = "End Date")]
        public DateTime FinishDate { get; set; }

        [Display(Name = "Time Limit")]
        public bool TimeLimit { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? Duration { get; set; }

        [Display(Name = "Calculate points automatically for each question")]
        public bool AutoPointsCalculation { get; set; }
        public CreateExamViewModel()
        {
            Questions = new List<CreateQuestionViewModel>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (StartDate.Date < DateTime.Now.Date)
            {
                errors.Add(new ValidationResult($"Starting date can't be in the past", new List<string> { nameof(StartDate) }));
            }
            if (FinishDate.Date < DateTime.Now.Date)
            {
                errors.Add(new ValidationResult($"End date can't be in the past", new List<string> { nameof(FinishDate) }));
            }
            else
            {
                if (FinishDate < StartDate)
                    errors.Add(new ValidationResult($"End date needs to be greater than starting date", new List<string> { nameof(FinishDate) }));
            }
            if (Questions.Count == 0)
            {
                errors.Add(new ValidationResult($"Exam must have at least one question", new List<string> { nameof(Questions) }));
            }
            return errors;
        }

    }
}
