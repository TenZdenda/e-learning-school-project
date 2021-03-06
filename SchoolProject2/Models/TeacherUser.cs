using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class TeacherUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [NotMapped] //ignore
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [NotMapped] //ignore
        public string ConfirmPassword { get; set; }
    }
}
