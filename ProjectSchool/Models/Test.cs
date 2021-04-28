using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool.Models
{
    public class Test
    {
        public int TestId { get; set; }

        public string TestName { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public int NumOfQuestions { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }

        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
    }
}
