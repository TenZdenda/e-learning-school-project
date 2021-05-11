using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;

namespace SchoolProject2.Areas.Admin.Pages
{
    public class ScheduleModel : PageModel
    {
        private readonly IAdminService _db;

        public ScheduleModel(IAdminService db)
        {
            _db = db;
        }

        

        public void OnGet()
        {
        }


    }
}
