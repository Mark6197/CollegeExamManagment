using Domain.Exams;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Exams
{
    public class AnswerConfiguration
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(a => a.Text).IsRequired().HasMaxLength(500);
        }
    }
}
