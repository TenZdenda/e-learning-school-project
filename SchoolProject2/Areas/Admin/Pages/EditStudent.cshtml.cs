using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using SchoolProject2.Utility;

namespace SchoolProject2.Areas.Admin.Pages
{
    [Authorize(Roles = SD.AdminUser)]
    public class EditStudentModel : PageModel
    {
        private readonly IAdminService _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        //[BindProperty]
        //public StudentUser Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        public EditStudentModel(IAdminService db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
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


        //public async Task<IdentityRole> GetUserRoleOrNullAsync(IdentityUser userFromDb)
        //{
        //    foreach (var role in _roleManager.Roles)
        //    {
        //        if (await _userManager.IsInRoleAsync(userFromDb, role.Name))
        //        {
        //            var returnedRole = new IdentityRole(role.Name);
        //            return returnedRole;
        //        }
        //    }
        //    return null;
        //}

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
                //var roleResult = await _userManager.IsInRoleAsync(userFromDb, id);
                //Input.CurrentRole = roleResult.
                Input.CurrentRoleName = await _db.GetUserRoleOrNullAsync(userFromDb.Id);
            }

            //Input.Name = Students.Name;
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
                return RedirectToPage("AllStudents");

            return Page();
            




            //var userFromDb = await _userManager.FindByIdAsync(id);

            //var type = userFromDb.GetType().Name;

            //if (userFromDb is not null)
            //{



                //switch (type)
                //{
                //    case nameof(StudentUser):
                //        var castedStudent = userFromDb as StudentUser;
                //        Input.Name = castedStudent.Name;
                //        if (castedStudent is not null)
                //        {
                //            var result = await _db.UpdateUser(castedStudent)
                //        }
                //        break;
                //    case nameof(AdminUser):
                //        var castedAdmin = userFromDb as AdminUser;
                //        Input.Name = castedAdmin.Name;
                //        break;
                //    case nameof(TeacherUser):
                //        var castedTeacher = userFromDb as TeacherUser;
                //        Input.Name = castedTeacher.Name;
                //        break;
                //}

            //}


            //var result = await _db.UpdateStudent(student);

            //if (result)
            //    return RedirectToPage("AllStudents");
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "User not created");
            //    return Page();
            //}
        }
    }
}
