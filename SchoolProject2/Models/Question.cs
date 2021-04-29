using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class Question
    {
        [Required]
        [MaxLength(50)]
        public int QuestionId { get; set; }


        public int TestId { get; set; }
        [ForeignKey(nameof(TestId))]
        public virtual Test Test { get; set; }
        
        public string TheQuestion { get; set; }

        public string Choice { get; set; }
    }
}
