using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.ExamViewModels
{
    public class CreateAssignedExamVM: IValidatableObject
    {
        [Display(Name = "Exam")]
        public long ExamId { get; set; }

        public long CourseId { get; set; }
        public long TeacherId { get; set; }
        public string CourseName { get; set; }
        public bool IsCreated { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]
        public DateTime FinishDate { get; set; }


        public CreateAssignedExamVM()
        {
            StartDate = DateTime.Now;
            FinishDate = DateTime.Now.AddDays(1);
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
                errors.Add(new ValidationResult($"Finish date can't be in the past", new List<string> { nameof(FinishDate) }));
            }
            if (FinishDate < StartDate)
            {
                errors.Add(new ValidationResult($"Finish date needs to be greater than starting date", new List<string> { nameof(FinishDate) }));
            }
            if (ExamId==0)
            {
                errors.Add(new ValidationResult($"Please choose which exam to assign", new List<string> { nameof(ExamId) }));
            }
            return errors;
        }
    }
}
