using Microsoft.AspNetCore.Identity;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Data.Repository
{
    public interface IStudentService
    {
        Task<IEnumerable<Schedule>> GetAllSchedules();
        Task<IEnumerable<Course>> GetAllCourses();
    }
}
