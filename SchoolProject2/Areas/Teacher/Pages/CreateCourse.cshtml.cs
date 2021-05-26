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
    public class CreateCourseModel : PageModel
    {
        private readonly IAdminService _db;

        [BindProperty]
        public Course Course { get; set; }

        public CreateCourseModel(IAdminService db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _db.AddCourse(Course);

            if (result)
                TempData["SM"] = $"Course {Course.CourseName} has been successfully edited";
            else
                TempData["FM"] = $"Course {Course.CourseName} editing failed";

            if (result)
                return RedirectToPage("AllCourses");
            else
            {
                ModelState.AddModelError(string.Empty, "Course not created");
                return Page();
            }
        }
    }
}
