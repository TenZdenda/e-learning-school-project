using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Data.EFRepository
{
    public class EFStudentService : IStudentService
    {
        ApplicationDbContext context;

        public EFStudentService(ApplicationDbContext db)
        {
            context = db;
        }
        public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            var result = await context.Schedules.Include(s => s.Course).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var result = await context.Courses.ToListAsync();
            return result;
        }
    }
}
