using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class StudentUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
