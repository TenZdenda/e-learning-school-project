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
    public class IndexModel : PageModel
    {
        private readonly IAdminService _db;

        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<StudentUser> Students { get; set; }
        public IEnumerable<TeacherUser> Teachers { get; set; }

        public IndexModel(IAdminService db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Courses = await _db.GetAllCourses();
            Students = await _db.GetAllStudents();
            Teachers = await _db.GetAllTeachers();
            return Page();
        }
    }
}
