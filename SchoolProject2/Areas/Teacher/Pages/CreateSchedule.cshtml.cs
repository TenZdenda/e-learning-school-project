using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using SchoolProject2.Utility;

namespace SchoolProject2.Areas.Teacher.Pages
{
    [Authorize(Roles = SD.TeacherUser)]
    public class CreateScheduleModel : PageModel
    {
        private readonly IAdminService _db;

        [BindProperty]
        public Schedule Schedule { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public CreateScheduleModel(IAdminService db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Courses = await _db.GetAllCourses();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _db.AddSchedule(Schedule);

            if (result)
                TempData["SM"] = $"Schedule for course {Schedule.Course} has been successfully edited";
            else
                TempData["FM"] = $"Schedule for course {Schedule.Course} editing failed";

            if (result)
                return RedirectToPage("AllSchedules");
            else
            {
                ModelState.AddModelError(string.Empty, "Schedule not created");
                return Page();
            }
        }
    }
}
