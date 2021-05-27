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

namespace SchoolProject2.Areas.Teacher.Pages
{
    [Authorize(Roles = SD.TeacherUser)]
    public class IndexModel : PageModel
    {
        private readonly ITeacherService _db;

        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<StudentUser> Students { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }

        public IndexModel(ITeacherService db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Courses = await _db.GetAllCourses();
            Students = await _db.GetAllStudents();
            Schedules = await _db.GetAllSchedules();
            return Page();
        }
    }
}
