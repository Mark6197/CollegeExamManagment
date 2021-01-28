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
            CreateMap<Exam, CreateExamViewModel>().ReverseMap();

            CreateMap<Question, CreateQuestionViewModel>().ReverseMap();

            CreateMap<Answer, CreateAnswerViewModel>().ReverseMap();

        }
    }
}
