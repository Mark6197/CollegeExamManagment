using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamsWebApp.Areas.Identity.Data
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppRole>().HasData(new List<AppRole>
            {
                new AppRole {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole {
                    Id = 2,
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
                },
                new AppRole {
                    Id = 3,
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
            });
        }
    }
}
