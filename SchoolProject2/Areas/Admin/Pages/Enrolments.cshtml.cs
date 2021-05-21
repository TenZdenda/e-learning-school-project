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
    public class EnrolmentsModel : PageModel
    {
        private readonly IAdminService _db;
        public Course Courses { get; set; }
        public EnrolmentsModel(IAdminService db)
        {
            _db = db;
        }
        public async Task OnGetAsync(int id)
        {
            Courses = await _db.GetCourseAndStudentByIdAsync(id);
        }
    }
}
