using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Test")]
        public int TestId { get; set; }
        public int Mark { get; set; }
        public int Grade { get; set; }
    }
}
