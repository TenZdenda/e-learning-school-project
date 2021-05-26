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
    public class EditScheduleModel : PageModel
    {
        private readonly IAdminService _db;

        public EditScheduleModel(IAdminService db)
        {
            _db = db;

        }

        [BindProperty(SupportsGet = true)]
        public Schedule Schedule { get; set; }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<Course> Courses { get; set; }

        public async Task OnGetAsync(int id)
        {
            Schedule = await _db.GetScheduleByIdOrNullAsync(id);
            Courses = await _db.GetAllCourses();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _db.UpdateScheduleAsync(Schedule);

            if (result)
                TempData["SM"] = $"Schedule {Schedule.ScheduleId} has been successfully edited";
            else
                TempData["FM"] = $"Schedule {Schedule.ScheduleId} editing failed";

            return RedirectToPage("AllSchedules");

        }
    }
}
