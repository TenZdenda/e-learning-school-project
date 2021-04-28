using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Models
{
    public class Response
    {
        public int ResponseId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public string SelectedChoice { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
    }
}
