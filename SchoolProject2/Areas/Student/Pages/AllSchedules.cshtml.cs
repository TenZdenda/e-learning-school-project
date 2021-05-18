using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;

namespace SchoolProject2.Areas.Student.Pages
{
    public class AllSchedulesModel : PageModel
    {
        private readonly IStudentService _db;

        public IEnumerable<Schedule> Schedules { get; set; }

        public AllSchedulesModel(IStudentService db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Schedules = await _db.GetAllSchedules();
            return Page();
        }

        
    }
}

