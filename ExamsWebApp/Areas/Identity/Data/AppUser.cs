using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ExamsWebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser<long>
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(25)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(25)")]
        public string LastName { get; set; }
    }
}
