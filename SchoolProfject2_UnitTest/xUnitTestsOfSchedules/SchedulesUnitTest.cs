using Microsoft.EntityFrameworkCore;
using SchoolProfject2_UnitTest.xUnitTestsOfSchedules;
using SchoolProject2.Data;
using SchoolProject2.Data.EFRepository;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolProject2_UnitTest.xUnitTestsOfSchedules
{
    public class SchedulesUnitTest : EFTestDataServiceOfSchedules
    {
        public SchedulesUnitTest() : base(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Filename=Test.db").Options)
        {

        }

       [Fact]
        public void Add_Schedule_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);

                Schedule sc3 = new Schedule() { ScheduleId = 3, DayOfWeek = DayOfWeek.Thursday, StartTime = new DateTime(2021, 05, 27, 8, 0, 0), EndTime = new DateTime(2021, 05, 27, 10, 0, 0) };

                service.AddSchedule(sc3);
                
                Assert.Equal(3, context.Schedules.ToList().Count());
                Assert.True(context.Schedules.ToList()[2].ScheduleId == 3);
            }
        }

        [Fact]
        public void Get_All_Schedules_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);
                
                var Schedules = service.GetAllSchedules().Result;
                
                Assert.Equal(2, Schedules.Count());
                Assert.True(Schedules.ToList()[0].ScheduleId == 1 && Schedules.ToList()[0].DayOfWeek == DayOfWeek.Wednesday);
                Assert.True(Schedules.ToList()[1].ScheduleId == 2 && Schedules.ToList()[1].DayOfWeek == DayOfWeek.Tuesday);
            }
        }

        [Fact]
        public async void Delete_Schedule_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);

                await service.DeleteSchedule(1);

                Assert.Equal(1, context.Schedules.ToList().Count);
                Assert.True(context.Schedules.ToList()[0].ScheduleId == 2 && context.Schedules.ToList()[0].DayOfWeek == DayOfWeek.Tuesday);
            }
        }

        [Fact]
        public async void Update_Schedule_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);

                Schedule sc1 = new Schedule() { ScheduleId = 1, DayOfWeek = DayOfWeek.Monday, StartTime = new DateTime(2021, 05, 27, 8, 0, 0), EndTime = new DateTime(2021, 05, 27, 10, 0, 0) };
                await service.UpdateScheduleAsync(sc1);

                Assert.True(context.Schedules.ToList()[0].ScheduleId == 1 && context.Schedules.ToList()[0].DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}
