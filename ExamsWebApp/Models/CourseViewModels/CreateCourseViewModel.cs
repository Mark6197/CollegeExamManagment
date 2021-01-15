using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.CourseViewModels
{
    public class CreateCourseViewModel: IValidatableObject
    {
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50,MinimumLength =5, ErrorMessage = "Name must be minimum of 5 and maximum 1000 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000,MinimumLength =10, ErrorMessage = "Description must be minimum of 10 and maximum 1000 characters")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Finish Date is required")]
        [Display(Name = "Finish Date")]
        public DateTime FinishDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (StartDate.Date <DateTime.Now.Date)
            {
                errors.Add(new ValidationResult($"Starting date can't be in the past", new List<string> { nameof(StartDate) }));
            }    
            if (FinishDate.Date <DateTime.Now.Date)
            {
                errors.Add(new ValidationResult($"Finish date can't be in the past", new List<string> { nameof(FinishDate) }));
            }
            if (FinishDate < StartDate)
            {
                errors.Add(new ValidationResult($"Finish date needs to be greater than starting date.", new List<string> { nameof(FinishDate) }));
            }
            return errors;
        }
    }
}
