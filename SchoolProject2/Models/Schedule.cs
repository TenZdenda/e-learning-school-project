using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
       
        public virtual Course Course { get; set; }

    }
}
