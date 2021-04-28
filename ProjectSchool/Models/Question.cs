using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }

        public string TheQuestion { get; set; }

        public string Choice { get; set; }

    }
}
