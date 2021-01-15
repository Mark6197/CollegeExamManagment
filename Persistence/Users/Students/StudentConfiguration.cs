using Domain.Users.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Users.Students
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Id).ValueGeneratedNever();
            builder.Property(s => s.FullName).IsRequired().HasMaxLength(51);
            builder.Property(s => s.StudentNum).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
