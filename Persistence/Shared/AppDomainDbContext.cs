using Domain.Courses;
using Domain.Exams;
using Domain.Users.Students;
using Domain.Users.Teachers;
using Microsoft.EntityFrameworkCore;
using Persistence.Courses;
using Persistence.Exams;
using Persistence.Users.Students;
using Persistence.Users.Teachers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Shared
{
    public class AppDomainDbContext : DbContext
    {
        public AppDomainDbContext(DbContextOptions<AppDomainDbContext> options) : base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StudentConfiguration().Configure(modelBuilder.Entity<Student>());
            new TeacherConfiguration().Configure(modelBuilder.Entity<Teacher>());
            new CourseConfiguration().Configure(modelBuilder.Entity<Course>());
            new ExamConfiguration().Configure(modelBuilder.Entity<Exam>());
            new StudentExamConfiguration().Configure(modelBuilder.Entity<StudentExam>());
            new StudentQuestionConfiguration().Configure(modelBuilder.Entity<StudentQuestion>());
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        //public DbSet<StudentExam> StudentsExams { get; set; }
        //public DbSet<Question> Questions { get; set; }
    }
}
 