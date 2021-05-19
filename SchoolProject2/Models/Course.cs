using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class Course
    {
        public int CourseId { get; set; }
                
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [Required]
        public int Duration { get; set; }
        
        public string TeacherUserId { get; set; }
        [ForeignKey(nameof(TeacherUserId))]
        public virtual TeacherUser TeacherUser { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<StudentUser> StudentUsers { get; set; }
    }
}
