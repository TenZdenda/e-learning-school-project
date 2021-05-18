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
                return RedirectToPage("AllSchedules");
            else
            {
                ModelState.AddModelError(string.Empty, "Schedule not created");
                return Page();
            }
        }
    }
}
