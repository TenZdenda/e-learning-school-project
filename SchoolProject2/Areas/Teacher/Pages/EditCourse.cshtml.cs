using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using SchoolProject2.Utility;

namespace SchoolProject2.Areas.Teacher.Pages
{
    [Authorize(Roles = SD.TeacherUser)]
    public class EditCourseModel : PageModel
    {
        private readonly ITeacherService _db;

        public EditCourseModel(ITeacherService db)
        {
            _db = db;

        }

        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Name { get; set; }
            public SelectList AllUsers { get; set; }
            public string CurrentUserId { get; set; }
        }


        [BindProperty(SupportsGet = true)]
        public Course Course { get; set; }

        [BindProperty]
        public List<StudentUser> Students { get; set; }

        public async Task OnGetAsync(int id)
        {
            Course = await _db.GetCourseByIdOrNullAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(string userName = null)
        {
            if (!ModelState.IsValid)
                return Page();

            if (!string.IsNullOrWhiteSpace(userName))
            {
                await SearchUser(Course.CourseId, userName);
                return Page();
            }

            bool result;

            if (string.IsNullOrWhiteSpace(Input.CurrentUserId))
                result = await _db.UpdateCourseAsync(Course);
            else
                result = await _db.UpdateCourseAsync(Course, Input.CurrentUserId);

            if (result)
                TempData["SM"] = $"Course {Course.CourseName} has been successfully edited";
            else
                TempData["FM"] = $"Course {Course.CourseName} editing failed";

            return RedirectToPage("AllCourses");

        }


        public async Task SearchUser(int id, string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return;

            Course = await _db.GetCourseByIdOrNullAsync(id);
            var rawStudentsArr = await _db.GetAllStudents();
            Students = rawStudentsArr.Where(x =>
                x.Name.Contains(userName) ||
                x.Email.Contains(userName)
            ).ToList();

            Input.AllUsers = new SelectList(Students, "Id", "Email");

        }
    }
}
