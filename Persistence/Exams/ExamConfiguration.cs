using Domain.Courses;
using Domain.Exams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Exams
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {

            builder.HasDiscriminator(e => e.ExamType).HasValue<Exam>(ExamType.Exam).HasValue<AssignedExam>(ExamType.AssignedExam);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50).HasColumnName("Title");
            builder.Property(c => c.Duration).HasColumnType("Time").HasColumnName("Duration");
            builder.Property(c => c.TeacherId).HasColumnName("TeacherId");
            builder.Property(c => c.AutoPointsCalculation).HasColumnName("AutoPointsCalculation");
        }
    }
}
