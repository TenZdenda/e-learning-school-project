using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;

namespace SchoolProject2.Areas.Admin.Pages
{
    public class EditStudentModel : PageModel
    {
        private readonly IAdminService _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public StudentUser Students { get; set; }

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
            public List<IdentityRole> AllRoles { get; set; }
            public IdentityRole CurrentRole { get; set; }
        }


        public async Task<IdentityRole> GetUserRoleOrNullAsync(IdentityUser user)
        {
            foreach (var role in _roleManager.Roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    var returnedRole = new IdentityRole(role.Name);
                    return returnedRole;
                }
            }
            return null;
        }

        public async Task OnGetAsync(string id)
        {
            Input.AllRoles = _roleManager.Roles.ToList();

            if (string.IsNullOrWhiteSpace(id))
                return;

            Students = await _db.GetStudent(id);
            var user = await _userManager.FindByIdAsync(id);

           
            if (user is not null)
            {
                //var roleResult = await _userManager.IsInRoleAsync(user, id);
                //Input.CurrentRole = roleResult.
            }

            Input.Name = Students.Name;





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
