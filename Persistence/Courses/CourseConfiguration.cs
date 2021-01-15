using Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Courses
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(1000);
            builder.Property(c => c.StartDate).HasColumnType("Date");
            builder.Property(c => c.FinishDate).HasColumnType("Date");
        }
    }
}
