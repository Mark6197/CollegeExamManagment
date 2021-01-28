
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.CourseViewModels
{
    public class CourseBasicDetailsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime FinishDate { get; set; }

        [Display(Name = "Students")]
        public int StudentsCount { get; set; }
    }
}
