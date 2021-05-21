using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class Enrolment
    {
        public int Id { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<StudentUser> StudentUsers { get; set; }
    }
}
