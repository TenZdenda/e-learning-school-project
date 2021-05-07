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
    public class AllTeachersModel : PageModel
    {

        private readonly IAdminService _db;
        public IEnumerable<TeacherUser> Teachers { get; set; }

        public AllTeachersModel(IAdminService db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Teachers = await _db.GetAllTeachers();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var result = await _db.DeleteTeacher(id);
            if (result)
            {
                Teachers = await _db.GetAllTeachers();
                return Page();
            }
            return Page();
        }
    }
}
