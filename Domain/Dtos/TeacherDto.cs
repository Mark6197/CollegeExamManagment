using System.Collections.Generic;

namespace Domain.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public IReadOnlyList<CourseDto> Courses { get; set; }
    }
}