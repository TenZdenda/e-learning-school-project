using Microsoft.EntityFrameworkCore;
using SchoolProject2.Data;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject2_UnitTest.xUnitTestsOfStudents
{
    public class EFTestDataServiceOfStudents
    {
        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        protected EFTestDataServiceOfStudents(DbContextOptions<ApplicationDbContext> contextOptions)
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
                context.StudentUsers.Add(new StudentUser() { Id = "S3", Name = "Stud3", Email = "S3@gmail.com", Password = "Abc+123", ConfirmPassword = "Abc+123" });
                context.StudentUsers.Add(new StudentUser() { Id = "S4", Name = "Stud4", Email = "S4@yahoo.com", Password = "Abc+123", ConfirmPassword = "Abc+123" });
                //context.Courses.Add(new Course() { CourseId = 1, CourseName = "sssss", Duration = 600, TeacherUserId = "xxxx2222" });
                //context.Courses.Add(new Course() { CourseId = 2, CourseName = "xxxx", Duration = 600, TeacherUserId = "xxxx2222" });

                context.SaveChanges();
            }
        }
    }
}
