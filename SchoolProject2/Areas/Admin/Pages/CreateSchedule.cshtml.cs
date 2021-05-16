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
    public class CreateScheduleModel : PageModel
    {
        private readonly IAdminService _db;

        [BindProperty]
        public Schedule Schedule { get; set; }

        public CreateScheduleModel(IAdminService db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _db.AddSchedule(Schedule);

            if (result)
                return RedirectToPage("AllSchedules");
            else
            {
                ModelState.AddModelError(string.Empty, "Schedule not created");
                return Page();
            }
        }
    }
}
