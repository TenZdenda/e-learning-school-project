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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }

        public int Duration { get; set; }

        [ForeignKey("TeacherUser")]
        public string? TeacherId { get; set; }

        //public virtual ICollection<StudentUser> StudentUsers { get; set; }
    }
}
