﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using SchoolProject2.Utility;

namespace SchoolProject2.Areas.Teacher.Pages
{
    [Authorize(Roles = SD.TeacherUser)]
    public class AllSchedulesModel : PageModel
    {
        private readonly ITeacherService _db;

        public IEnumerable<Schedule> Schedules { get; set; }

        [BindProperty]
        public Schedule Schedule { get; set; }

        public AllSchedulesModel(ITeacherService db)
        {
            _db = db;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            Schedules = await _db.GetAllSchedules();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Schedule = await _db.GetScheduleByIdOrNullAsync(id);

            var result = await _db.DeleteSchedule(id);

            if (result)
                TempData["SM"] = $"Schedule {(Schedule.Course.CourseName is null ? new Schedule() : Schedule.Course.CourseName)} has been successfully deleted";
            else
                TempData["FM"] = $"Schedule {(Schedule.Course.CourseName is null ? new Schedule() : Schedule.Course.CourseName)} has been failed to delete";

            if (result)
            {
                Schedules = await _db.GetAllSchedules();
                return Page();
            }
            return Page();
        }
    }
}
