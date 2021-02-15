using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.ExamViewModels
{
    public class GenericExamExtendedDetails
    {
        public GenericExamBasicDetailsVM BasicDetails { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
