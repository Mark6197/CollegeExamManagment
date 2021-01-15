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
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50);
            builder.Property(c => c.StartDate).HasColumnType("Date");
            builder.Property(c => c.FinishDate).HasColumnType("Date");
            builder.Property(c => c.Duration).HasColumnType("Time");
        }
    }
}
