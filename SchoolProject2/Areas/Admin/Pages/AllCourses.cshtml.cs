using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using SchoolProject2.Utility;

namespace SchoolProject2.Areas.Admin.Pages
{
    [Authorize(Roles = SD.AdminUser)]
    public class AllCoursesModel : PageModel
    {
        private readonly IAdminService _db;

        public IEnumerable<Course> Courses { get; set; }

        public AllCoursesModel(IAdminService db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Courses = await _db.GetAllCourses();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var result = await _db.DeleteCourse(id);
            if (result)
            {
                Courses = await _db.GetAllCourses();
                return Page();
            }
            return Page();
        }
    }
}
