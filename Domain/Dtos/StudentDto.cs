using System.Collections.Generic;

namespace Domain.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IReadOnlyList<CourseDto> Courses { get; set; }
    }
}