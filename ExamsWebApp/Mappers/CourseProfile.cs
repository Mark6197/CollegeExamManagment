using AutoMapper;
using Domain.Courses;
using ExamsWebApp.Models.CourseViewModels;


namespace ExamsWebApp.Mappers
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CreateCourseViewModel>().ReverseMap();
            CreateMap<Course, EditCourseViewModel>().ReverseMap();
            CreateMap<Course, CourseBasicDetailsViewModel>()
                .ForMember(c => c.StudentsCount, o => o.MapFrom(c => c.Students.Count));
        }
    }
}
