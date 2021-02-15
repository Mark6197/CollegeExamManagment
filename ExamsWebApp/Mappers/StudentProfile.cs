using AutoMapper;
using Domain.Users.Students;
using ExamsWebApp.Models.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Mappers
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentVM>();

        }
    }
}
