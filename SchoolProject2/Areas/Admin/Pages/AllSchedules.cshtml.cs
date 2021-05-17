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
    public class AllSchedulesModel : PageModel
    {
        private readonly IAdminService _db;

        public IEnumerable<Schedule> Schedules { get; set; }

        public AllSchedulesModel(IAdminService db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Schedules = await _db.GetAllSchedules();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var result = await _db.DeleteSchedule(id);
            if (result)
            {
                Schedules = await _db.GetAllSchedules();
                return Page();
            }
            return Page();
        }
    }
}
