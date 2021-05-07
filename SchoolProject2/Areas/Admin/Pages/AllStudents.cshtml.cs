using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using SchoolProject2.Utility;

namespace SchoolProject2.Areas.Admin.Pages
{
    public class AllStudentsModel : PageModel
    {
        private readonly IAdminService _db;

        public IEnumerable<StudentUser> Students { get; set; }

        public AllStudentsModel(IAdminService db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Students = await _db.GetAllStudents();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var result = await _db.DeleteStudent(id);
            if (result)
            {
                Students = await _db.GetAllStudents();
                return Page();
            }
            return Page();
        }
    }
}
