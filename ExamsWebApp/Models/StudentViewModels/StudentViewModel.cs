using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Models.StudentViewModels
{
    public class StudentViewModel
    {
        [Display(Name ="Name")]
        public string FullName { get; set; }
    }
}
