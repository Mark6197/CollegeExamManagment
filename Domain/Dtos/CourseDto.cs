using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CourseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public IReadOnlyList<StudentDto> Students { get; set; }
        public TeacherDto Teacher { get; set; }

    }
}
