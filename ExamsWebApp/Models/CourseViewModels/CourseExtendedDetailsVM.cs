using ExamsWebApp.Models.ExamViewModels;
using ExamsWebApp.Models.StudentViewModels;
using System.Collections.Generic;

namespace ExamsWebApp.Models.CourseViewModels
{
    public class CourseExtendedDetailsVM
    {
        public CourseBasicDetailsVM Details { get; set; }
        public List<StudentVM> Students { get; set; }
        public List<AssignedExamBasicDetailsVM> AssignedExams { get; set; }
        public long TeacherId { get; set; }

        public CourseExtendedDetailsVM()
        {
            Students = new List<StudentVM>();
            AssignedExams = new List<AssignedExamBasicDetailsVM>();
        }
    }
}
