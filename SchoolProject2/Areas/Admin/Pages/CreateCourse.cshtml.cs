using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;

namespace SchoolProject2.Areas.Admin.Pages
{
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
                return RedirectToPage("AllCourses");
            else
            {
                ModelState.AddModelError(string.Empty, "Course not created");
                return Page();
            }
        }
    }
}
