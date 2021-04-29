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
    public class CreateStudentModel : PageModel
    {
        private readonly IAdminService _db;
        public StudentUser Student { get; set; }
        public CreateStudentModel(IAdminService db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
    }
}
