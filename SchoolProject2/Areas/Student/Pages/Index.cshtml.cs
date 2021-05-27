using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Utility;

namespace SchoolProject2.Areas.Student.Pages
{
    [Authorize(Roles = SD.StudentUser)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
