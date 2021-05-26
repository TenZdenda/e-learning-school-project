using Microsoft.EntityFrameworkCore;
using SchoolProject2.Data;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProfject2_UnitTest.SchedulesUnitTest
{
    public class EFTestDataService
    {
        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        protected EFTestDataService(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Schedules.Add(new Schedule() { ScheduleId = 1, DayOfWeek = DayOfWeek.Wednesday, StartTime = new DateTime(2021, 05, 26, 8, 0, 0), EndTime = new DateTime(2021, 05, 26, 10, 0, 0) });

                context.SaveChanges();
            }
        }
    }
}
