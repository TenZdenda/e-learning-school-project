using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }

        
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual StudentUser StudentUser { get; set; }

        
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
