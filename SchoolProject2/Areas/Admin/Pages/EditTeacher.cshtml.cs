using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;

namespace SchoolProject2.Areas.Admin.Pages
{
    public class EditTeacherModel : PageModel
    {
        private readonly IAdminService _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        //[BindProperty]
        //public StudentUser Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        public EditTeacherModel(IAdminService db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public class InputModel
        {
            public string Name { get; set; }
            public SelectList AllRoles { get; set; }
            public string CurrentRoleName { get; set; }
        }



        public async Task OnGetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return;

            Input.AllRoles = new SelectList(await _db.GetAllRolesAsync(), "Name", "Name");

            var userFromDb = await _userManager.FindByIdAsync(id);

            var type = userFromDb.GetType().Name;

            switch (type)
            {
                case nameof(StudentUser):
                    var castedStudent = userFromDb as StudentUser;
                    Input.Name = castedStudent.Name;
                    break;
                case nameof(AdminUser):
                    var castedAdmin = userFromDb as AdminUser;
                    Input.Name = castedAdmin.Name;
                    break;
                case nameof(TeacherUser):
                    var castedTeacher = userFromDb as TeacherUser;
                    Input.Name = castedTeacher.Name;
                    break;
            }

            if (userFromDb is not null)
            {

                Input.CurrentRoleName = await _db.GetUserRoleOrNullAsync(userFromDb.Id);
            }

        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(Input.Name) && string.IsNullOrWhiteSpace(Input.CurrentRoleName))
            {
                ModelState.AddModelError(string.Empty, "Name or Role is empty");
                return Page();
            }

            var result = await _db.UpdateStudent(id, Input.Name, Input.CurrentRoleName);

            if (result)
                return RedirectToPage("AllTeachers");

            return Page();

        }
    }
}
