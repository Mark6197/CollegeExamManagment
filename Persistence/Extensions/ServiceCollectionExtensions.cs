using Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Courses;
using Persistence.Exams;
using Persistence.Shared;
using Persistence.Users.Students;
using Persistence.Users.Teachers;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<AppDomainDbContext>(options =>
              options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IAssignedExamRepository, AssignedExamRepository>();
        }
    }
}
