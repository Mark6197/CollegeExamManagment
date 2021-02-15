using Domain.Exams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.ExamViewModels
{
    public class GenericExamBasicDetailsVM
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<QuestionDetailsVM> Questions { get; set; }
        public ExamType ExamType { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? FinishDate { get; set; }

        public GenericExamBasicDetailsVM()
        {
            Questions = new List<QuestionDetailsVM>();
        }

    }
}
