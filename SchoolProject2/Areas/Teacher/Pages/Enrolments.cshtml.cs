using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;

namespace SchoolProject2.Areas.Teacher.Pages
{
    public class EnrolmentsModel : PageModel
    {
        private readonly ITeacherService _db;
        public Course Courses { get; set; }
        public EnrolmentsModel(ITeacherService db)
        {
            _db = db;
        }
        public async Task OnGetAsync(int id)
        {
            Courses = await _db.GetCourseAndStudentByIdAsync(id);
        }

        public async Task OnGetDeleteAsync(string userId, int courseId)
        {
            var result = await _db.RemoveUserFromCourseAsync(userId, courseId);

            if (result)
                TempData["SM"] = $"User has been successfully removed";
            else
                TempData["FM"] = $"User deleting failed";

            Courses = await _db.GetCourseAndStudentByIdAsync(courseId);
        }
    }
}
