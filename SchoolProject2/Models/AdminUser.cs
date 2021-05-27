using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class AdminUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //[MaxLength(100)]
        //public string RoadNameAndNumber { get; set; }

        //[MaxLength(100)]
        //public string AreaCodeAndTown { get; set; }
        
        //public int TestId { get; set; }
        //[ForeignKey(nameof(TestId))]
        //public virtual Test Test { get; set; }

        //public string TeacherId { get; set; }
        //[ForeignKey(nameof(TeacherId))]
        //public virtual TeacherUser Teacher { get; set; }
    }
}
