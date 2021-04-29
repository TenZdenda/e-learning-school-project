using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class TeacherUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        
        [MaxLength(100)]
        public string RoadNameAndNumber { get; set; }

        
        [MaxLength(100)]
        public string AreaCodeAndTown { get; set; }
    }
}
