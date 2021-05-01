using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;

namespace SchoolProject2.Areas.Admin.Pages
{
    public class AllStudentsModel : PageModel
    {
        private readonly IAdminService _db;
        public List<StudentUser> Students { get; set; }

        public AllStudentsModel(IAdminService db)
        {
            _db = db;
        }

        //[BindProperty]
        //public List<StudentUser> StudentUserList { get; set; }

        public void OnGet()
        {
            Students = _db.GetAllStudents();
            //Students = _db.GetAllStudents();
        }
    }
}
