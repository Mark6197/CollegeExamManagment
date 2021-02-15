using Domain.Exams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Exams
{
    public class AssignedExamConfiguration : IEntityTypeConfiguration<AssignedExam>
    {
        public void Configure(EntityTypeBuilder<AssignedExam> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50).HasColumnName("Title");
            builder.Property(c => c.StartDate).HasColumnType("Date");
            builder.HasOne(e=>e.Course).WithMany(c=>c.AssignedExams).OnDelete(DeleteBehavior.ClientCascade);
            builder.Property(c => c.FinishDate).HasColumnType("Date");
            builder.Property(c => c.Duration).HasColumnType("Time").HasColumnName("Duration");
            builder.Property(c => c.TeacherId).HasColumnName("TeacherId");
            builder.Property(c => c.AutoPointsCalculation).HasColumnName("AutoPointsCalculation");

        }
    }

}
