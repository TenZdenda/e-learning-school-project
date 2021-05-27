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
    public class CreateTeacherModel : PageModel
    {
        private readonly IAdminService _db;
        [BindProperty]
        public TeacherUser Teacher { get; set; }
        public CreateTeacherModel(IAdminService db)
        {
            _db = db;
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await _db.AddTeacher(Teacher);

            if (result)
                TempData["SM"] = $"Teacher {Teacher.Name} has been successfully created";
            else
                TempData["FM"] = $"Teacher {Teacher.Name} creation failed";

            if (result)
                return RedirectToPage("AllTeachers");
            else
            {
                ModelState.AddModelError(string.Empty, "User not created");
                return Page();
            }
        }
    }
}
