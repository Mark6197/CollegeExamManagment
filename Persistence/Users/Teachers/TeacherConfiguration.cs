using Domain.Users.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Users.Teachers
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(t => t.Id).ValueGeneratedNever();
            builder.Property(t => t.FullName).IsRequired().HasMaxLength(51);
            builder.Property(t => t.TeacherNum).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
