using Domain.Users.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Users.Students
{
    public class StudentExamConfiguration : IEntityTypeConfiguration<StudentExam>
    {
        public void Configure(EntityTypeBuilder<StudentExam> builder)
        {
            builder.HasKey(se =>
                    new
                    {
                        se.StudentId,
                        se.ExamId
                    });

            //builder.HasOne(se => se.Student)
            //       .WithMany(s => s.StudentsExams)
            //       .HasForeignKey(se => se.StudentId);

            //builder.HasOne(se => se.Exam)
            //       .WithMany(e => e.StudentsExams)
            //       .HasForeignKey(se => se.ExamId);
        }
    }
}