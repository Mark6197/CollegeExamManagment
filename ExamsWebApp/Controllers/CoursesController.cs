using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsWebApp.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
