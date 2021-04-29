using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectSchool.Models;

namespace ProjectSchool.Pages.Admins
{
    public class GetAdminsModel : PageModel
    {
        public IEnumerable<Admin> Admins { get; set; }

        public int Id { get; set; }
        public void OnGet()
        {
        }
    }
}
