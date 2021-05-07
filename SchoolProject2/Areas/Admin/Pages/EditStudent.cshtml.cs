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
    public class EditStudentModel : PageModel
    {
        private readonly IAdminService _db;

        [BindProperty]
        public StudentUser Students { get; set; }

        public EditStudentModel(IAdminService db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            Students = await _db.GetStudent(id);
            
            return RedirectToPage("AllStudents");
        }

        public async Task<IActionResult> OnPostAsync(StudentUser student)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await _db.UpdateStudent(student);

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
