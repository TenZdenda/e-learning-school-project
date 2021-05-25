using Microsoft.EntityFrameworkCore;
using SchoolProject2.Data;
using SchoolProject2.Data.EFRepository;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolProfject2_UnitTest.CoursesUnitTest
{
    public class CoursesUnitTest:EFTestDataService
    {
        public CoursesUnitTest() : base(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Filename=Test.db").Options)
        {

        }

        [Fact]
        public void Add_Course_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);
                TeacherUser t1 = new TeacherUser() { Id = "ttttttt", Email = "xyz@gmail.com"};
                Course c1 = new Course() { CourseId = 3, CourseName = "zzzz", Duration = 900, TeacherUserId = "ttttttt" };
             
                service.AddCourse(c1);
                //List<Course> Courses = new List<Course>();
                //Course = service.GetAllCourses();
                Assert.Equal(3, context.Courses.ToList().Count());
                Assert.True(context.Courses.ToList()[2].CourseName == "zzzz");
            }
        }

        [Fact]
        public void Get_All_Courses_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);
                //TeacherUser t1 = new TeacherUser() { Id = "ttttttt", Email = "xyz@gmail.com" };
                //Course c1 = new Course() { CourseId = 3, CourseName = "zzzz", Duration = 900, TeacherUserId = "ttttttt" };

                
               // IEnumerable<Course> Courses = new List<Course>();
               var Courses = service.GetAllCourses();
                //Course = service.GetAllCourses();
                Assert.Equal(2, context.Courses.ToList().Count());
               // Assert.True(context.Courses.ToList()[2].CourseName == "zzzz");
            }
        }
    }
}
