using Domain.Users.Students;
using ExamsWebApp.Models.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.CourseViewModels
{
    public class CourseExtendedDetailsViewModel
    {
        public CourseBasicDetailsViewModel Details { get; set; }
        public List<StudentViewModel> Students { get; set; }

        public CourseExtendedDetailsViewModel()
        {
            Students = new List<StudentViewModel>();
        }
    }
}
