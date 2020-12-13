using Domain.Common;
using Domain.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Exams
{
    public class Exam : Entity
    {

        [Required]
        [StringLength(50)]
        public string ExamName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public int ClassId { get; set; }

        public Course Course { get; set; }

        //public virtual ICollection<StudentExam> StudentsExams { get; set; }

        public int TeacherId { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }


        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }

        public int PointsConfigure { get; set; }
    }
}
