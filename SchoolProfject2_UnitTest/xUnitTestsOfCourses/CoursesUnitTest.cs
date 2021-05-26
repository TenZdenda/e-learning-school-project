using Microsoft.EntityFrameworkCore;
using SchoolProfject2_UnitTest.xUnitTestsOfCourses;
using SchoolProject2.Data;
using SchoolProject2.Data.EFRepository;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolProject2_UnitTest.xUnitTestsOfCourses
{
    public class CoursesUnitTest:EFTestDataServiceOfCourses
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
                TeacherUser t1 = new TeacherUser() { Id = "ttttttt", Name = "teacher1", Email = "xyz@gmail.com"};
                Course c1 = new Course() { CourseId = 3, CourseName = "zzzz", Duration = 900, TeacherUserId = "ttttttt" };
             
                service.AddCourse(c1);
                
                Assert.Equal(3, context.Courses.ToList().Count());
                Assert.True(context.Courses.ToList()[2].CourseName == "zzzz");
            }
        }

        [Fact]
        public async void Get_All_Courses_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);
                
                var Courses = await service.GetAllCourses();
                
                Assert.Equal(2, Courses.Count());
                Assert.True(Courses.ToList()[0].CourseName == "sssss" && context.Courses.ToList()[0].CourseId == 1);
                Assert.True(Courses.ToList()[1].CourseName == "xxxx" && context.Courses.ToList()[1].CourseId == 2);
            }
        }

        [Fact]
        public async void Delete_Course_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);

                await service.DeleteCourse(2);

                Assert.True(context.Courses.ToList().Count == 1);
                Assert.True(context.Courses.ToList()[0].CourseId ==1);
            }
        }

        [Fact]
        public async void Update_Course_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);

                TeacherUser t1 = new TeacherUser() { Id = "ttttttt", Email = "xyz@gmail.com" };
                Course c1 = new Course() { CourseId = 1, CourseName = "TEST", Duration = 1, TeacherUserId = "test" };
                
                await service.UpdateCourseAsync(c1);
                                
                Assert.True(context.Courses.ToList()[0].CourseId == 1 && context.Courses.ToList()[0].CourseName == "TEST" && context.Courses.ToList()[0].Duration == 1 && context.Courses.ToList()[0].TeacherUserId == "test");
            }
        }

        [Fact]
        public async void Update_CourseWithStudent_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);

                context.StudentUsers.Add(new StudentUser() { Id = "testst", Name = "Stud1", Email = "S1@gmail.com", Password = "Abc+123", ConfirmPassword = "Abc+123" });
                Course c1 = new Course() { CourseId = 1, CourseName = "TEST", Duration = 1, TeacherUserId = "test" };

                await service.UpdateCourseAsync(c1, "testst");

                Assert.True(context.Courses.ToList()[0].CourseId == 1 && context.Courses.ToList()[0].CourseName == "TEST" && context.Courses.ToList()[0].Duration == 1); // && context.Courses.ToList()[0].StudentUsers.ToList()[2].Id == "testst"
            }
        }
    }
}
