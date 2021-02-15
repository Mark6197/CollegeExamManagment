using AutoMapper;
using Domain.Exams;
using ExamsWebApp.Models.ExamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Mappers
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, CreateExamVM>().ReverseMap();

            CreateMap<Question, CreateQuestionVM>().ReverseMap();

            CreateMap<Answer, CreateAnswerVM>().ReverseMap();

            CreateMap<Exam, GenericExamBasicDetailsVM>();

            CreateMap<Exam, GenericExamExtendedDetails>()
                .ForMember(dest=> dest.BasicDetails,opt=>opt.MapFrom(src=>src));

            CreateMap<AssignedExam, GenericExamBasicDetailsVM>();

            CreateMap<AssignedExam, CreateAssignedExamVM>().ReverseMap();

            CreateMap<AssignedExam, AssignedExamBasicDetailsVM>();

            CreateMap<Exam, GenericExamBasicDetailsVM>()
                .ForMember(dest=>dest.Questions,opt=>opt.MapFrom(src=>src.Questions)); 
            
            CreateMap<Question, QuestionDetailsVM>()
                .ForMember(dest=>dest.Answers,opt=>opt.MapFrom(src=>src.Answers));  
            
            CreateMap<Answer, AnswerDetailsVM>();
        }
    }
}
