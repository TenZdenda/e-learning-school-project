using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolProject2.Data;

namespace SchoolProject2.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            public string Name { get; set; }
            public string Email { get; set; }
            public string AreaCodeAndTown { get; set; }
            public string RoadNameAndNumber { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            //var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //var email = await _userManager.GetEmailAsync(user);
            var userFromDb = await _db.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

            Username = userFromDb.UserName;

            

            Input = new InputModel
            {
                Email = userFromDb.Email,
                PhoneNumber = userFromDb.PhoneNumber,
                //AreaCodeAndTown = userFromDb.AreaCodeAndTown,
                Name = userFromDb.UserName,
                //RoadNameAndNumber = userFromDb.RoadNameAndNumber,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}

            var userFromDb = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            userFromDb.UserName = Input.Name;
            userFromDb.Email = Input.Email;
            //userFromDb.RoadNameAndNumber = Input.RoadNameAndNumber;
            //userFromDb.AreaCodeAndTown = Input.AreaCodeAndTown;
            userFromDb.PhoneNumber = Input.PhoneNumber;

            await _db.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
