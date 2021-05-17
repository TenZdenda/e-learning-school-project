using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;

namespace SchoolProject2.Areas.Admin.Pages
{
    public class EditCourseModel : PageModel
    {
        private readonly IAdminService _db;

        public EditCourseModel(IAdminService db)
        {
            _db = db;
            
        }

        [BindProperty(SupportsGet = true)]
        public Course Course { get; set; }

        public async Task OnGetAsync(int id)
        {

            
            


        }

        public async Task<IActionResult> OnPostAsync(Course course)
        {
            var result = await _db.UpdateCourseAsync(course);
            
            
            return RedirectToPage("AllCourses");

        }
    }
}
