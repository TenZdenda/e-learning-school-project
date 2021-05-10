using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialId { get; set; }

        public string MaterialName { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        //public virtual StudentUser StudentUser { get; set; }
        
    }
}
