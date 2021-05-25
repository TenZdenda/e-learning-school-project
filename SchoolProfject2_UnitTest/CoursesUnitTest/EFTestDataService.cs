using Microsoft.EntityFrameworkCore;
using SchoolProject2.Data;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProfject2_UnitTest.CoursesUnitTest
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
                context.Courses.Add(new Course() { CourseId = 1, CourseName = "sssss", Duration = 600, TeacherUserId = "xxxx2222"});
                context.Courses.Add(new Course() { CourseId = 2, CourseName = "xxxx", Duration = 600, TeacherUserId = "xxxx2222" });
                //context.Movies.Add(new Movie() { Id = 2, Title = "Rocky", Year = 1982, RunningTimeInMins = 223, StudioId = 1 });


                context.SaveChanges();
            }
        }
    }
}
