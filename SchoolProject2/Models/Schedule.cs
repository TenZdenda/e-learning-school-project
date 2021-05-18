using Microsoft.AspNetCore.Mvc;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Models
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }

        //public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        [BindProperty, DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        //public LocalTime StartTime { get; set; }
        //public LocalTime EndTime { get; set; }

        [BindProperty, DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }

        // public Course course { get; set; }

    }
}
