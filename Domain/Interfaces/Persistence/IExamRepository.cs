using Domain.Exams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IExamRepository : IRepository<Exam>
    {
        Task<Exam> GetNotAssignedFullExamAsync(long examId);

        Task<IEnumerable<Exam>> GetNotAssignedExamsByTeacherAsync(long teacherId);

        IEnumerable<Exam> GetAllExamsWithCoursesByTeacher(long teacherId);

        Task<Exam> GetExamWithQuestionsAndAnswerAsync(long examId);


    }
}
