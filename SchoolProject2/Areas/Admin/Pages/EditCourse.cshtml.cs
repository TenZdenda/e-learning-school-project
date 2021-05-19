using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using SchoolProject2.Utility;

namespace SchoolProject2.Areas.Admin.Pages
{
    [Authorize(Roles = SD.AdminUser)]
    public class EditCourseModel : PageModel
    {
        private readonly IAdminService _db;

        public EditCourseModel(IAdminService db)
        {
            _db = db;
            
        }

        [BindProperty(SupportsGet = true)]
        public Course Course { get; set; }

        [BindProperty]
        public List<StudentUser> Students { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {            
            Course = await _db.GetCourseByIdOrNullAsync(id);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _db.UpdateCourseAsync(Course);

            if (result)
                TempData["SM"] = $"Course {Course.CourseName} has been successfully edited";
            else
                TempData["FM"] = $"Course {Course.CourseName} editing failed";

            return RedirectToPage("AllCourses");

        }

        public async Task OnPostSearchUser(string userName)
        {
            var rawStudentsArr = await _db.GetAllStudents();
            Students = rawStudentsArr.Where(x =>
                x.Name.Contains(userName) ||
                x.Email.Contains(userName)
            ).ToList();
        }
    }
}
