using Microsoft.EntityFrameworkCore;
using SchoolProfject2_UnitTest.CoursesUnitTest;
using SchoolProject2.Data;
using SchoolProject2.Data.EFRepository;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolProject2_UnitTest.CoursesUnitTest
{
    public class SchedulesUnitTest : EFTestDataService
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

                Schedule s1 = new Schedule() { ScheduleId = 2, DayOfWeek = DayOfWeek.Thursday, StartTime = new DateTime(2021, 05, 27, 8, 0, 0), EndTime = new DateTime(2021, 05, 27, 10, 0, 0) };
             
                service.AddSchedule(s1);
                //List<Course> Courses = new List<Course>();
                //Course = service.GetAllCourses();
                Assert.Equal(2, context.Schedules.ToList().Count());
                Assert.True(context.Schedules.ToList()[2].ScheduleId == 2);
            }
        }

        [Fact]
        public void Get_All_Schedules_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);
                //TeacherUser t1 = new TeacherUser() { Id = "ttttttt", Email = "xyz@gmail.com" };
                //Course c1 = new Course() { CourseId = 3, CourseName = "zzzz", Duration = 900, TeacherUserId = "ttttttt" };

                
                // IEnumerable<Course> Courses = new List<Course>();
                var Schedules = service.GetAllSchedules();
                //Course = service.GetAllCourses();
                Assert.Equal(1, context.Schedules.ToList().Count());
                // Assert.True(context.Courses.ToList()[2].CourseName == "zzzz");
            }
        }
    }
}
