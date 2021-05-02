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
        //private readonly ApplicationDbContext _db;
        public IEnumerable<StudentUser> Student { get; set; }

        public AllStudentsModel(IAdminService db /*ApplicationDbContext db*/)
        {
            _db = db;
        }

        //[BindProperty]
        //public List<StudentUser> StudentUserList { get; set; }

        public void OnGet()
        {
            
            //Students = _db.GetAllStudents().Where(user => user.Name == "Kristiin").ToList();
            Student = _db.GetAllStudents();
        }
    }
}
