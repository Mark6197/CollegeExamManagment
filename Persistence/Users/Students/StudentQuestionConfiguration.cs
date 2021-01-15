using Domain.Users.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Users.Students
{
    public class StudentQuestionConfiguration : IEntityTypeConfiguration<StudentQuestion>
    {
        public void Configure(EntityTypeBuilder<StudentQuestion> builder)
        {
            builder.HasKey(se =>
                    new
                    {
                        se.StudentId,
                        se.QuestionId
                    });

            //builder.HasOne(sq => sq.Student)
            //       .WithMany(s => s.StudentQuestion)
            //       .HasForeignKey(sq => sq.StudentId);

            //builder.HasOne(sq => sq.Question)
            //       .WithMany(q => q.StudentsQuestions)
            //       .HasForeignKey(sq => sq.ExamId);
        }
    }
}