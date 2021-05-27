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
    public class CreateStudentModel : PageModel
    {
        private readonly IAdminService _db;
        
        [BindProperty]
        public StudentUser Student { get; set; }
        
        public CreateStudentModel(IAdminService db)
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
            var result = await _db.AddStudent(Student);

            if (result)
                TempData["SM"] = $"Student {Student.Name} has been successfully created";
            else
                TempData["FM"] = $"Student {Student.Name} editing failed";

            if (result)
                return RedirectToPage("AllStudents");
            else
            {
                ModelState.AddModelError(string.Empty, "User not created");
                return Page();
            }
        }
    }
}
