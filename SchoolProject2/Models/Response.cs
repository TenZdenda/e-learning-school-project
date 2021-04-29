using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class Response
    {
        public int Id { get; set; }

        
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual StudentUser StudentUser { get; set; }

        
        public int QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public virtual Question Question { get; set; }

        public string SelectedChoice { get; set; }

        
        public int TestId { get; set; }
        [ForeignKey(nameof(TestId))]
        public virtual Test Test { get; set; }
    }
}
