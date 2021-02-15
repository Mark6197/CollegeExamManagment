using AutoMapper;
using Domain.Courses;
using ExamsWebApp.Models.CourseViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamsWebApp.Mappers
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CreateCourseVM>().ReverseMap();
            CreateMap<Course, EditCourseVM>().ReverseMap();
            CreateMap<Course, CourseBasicDetailsVM>()
                .ForMember(c => c.StudentsCount, o => o.MapFrom(c => c.Students.Count));   
            
            CreateMap<Course, CourseExtendedDetailsVM>()
                .ForMember(c => c.Details, o => o.MapFrom(c => c))
                .ForMember(c => c.Students, o => o.MapFrom(c => c.Students))
                .ForMember(c => c.AssignedExams, o => o.MapFrom(c => c.AssignedExams));
        }
    }
}
