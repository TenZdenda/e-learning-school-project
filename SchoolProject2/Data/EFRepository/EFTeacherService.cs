using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using SchoolProject2.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Data.EFRepository
{
    public class EFTeacherService : ITeacherService
    {

        ApplicationDbContext context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EFTeacherService(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            context = db;
            _roleManager = roleManager;
        }

        public EFTeacherService(ApplicationDbContext db)
        {
            context = db;
        }

        public bool AddCourse(Course course)
        {
            try
            {
                if (course != null)
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public bool AddSchedule(Schedule schedule)
        {
            try
            {
                if (schedule != null)
                {
                    context.Schedules.Add(schedule);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public async Task<bool> AddStudent(StudentUser student)
        {
            try
            {
                if (student != null)
                {
                    var user = new StudentUser
                    {
                        UserName = student.Email,
                        Email = student.Email,
                        Name = student.Name,
                        PhoneNumber = student.PhoneNumber
                    };
                    var result = await _userManager.CreateAsync(user, student.Password);

                    if (result.Succeeded)
                    {
                        if (!await _roleManager.RoleExistsAsync(SD.StudentUser))
                            await _roleManager.CreateAsync(new IdentityRole(SD.StudentUser));

                        await _userManager.AddToRoleAsync(user, SD.StudentUser);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            try
            {
                if (id == 0)
                    return false;

                var courseFromDb = await context.Courses.FindAsync(id);

                if (courseFromDb == null)
                    return false;

                context.Remove(courseFromDb);

                await context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public async Task<bool> DeleteSchedule(int id)
        {
            try
            {
                if (id == 0)
                    return false;

                var ScheduleFromDb = await context.Schedules.Include(x => x.Course).FirstOrDefaultAsync(x => x.ScheduleId == id);

                if (ScheduleFromDb == null)
                    return false;

                context.Remove(ScheduleFromDb);

                await context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            try
            {
                var result = await context.Courses.ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            try
            {
                var result = await context.Schedules.Include(s => s.Course).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task<IEnumerable<StudentUser>> GetAllStudents()
        {
            try
            {
                var result = await context.StudentUsers.ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task<Course> GetCourseAndStudentByIdAsync(int id)
        {
            try
            {
                var result = await context.Courses.Include(x => x.StudentUsers).FirstOrDefaultAsync(x => x.CourseId == id);
                return (result is null) ? null : result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task<Course> GetCourseByIdOrNullAsync(int id)
        {
            try
            {
                var result = await context.Courses.FindAsync(id);
                return (result is null) ? null : result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task<Schedule> GetScheduleByIdOrNullAsync(int id)
        {
            try
            {
                var result = await context.Schedules.FindAsync(id);
                return (result is null) ? null : result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task<StudentUser> GetStudent(string id)
        {
            try
            {
                var result = await context.StudentUsers.FindAsync(id);
                return result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task<bool> RemoveUserFromCourseAsync(string userId, int courseId)
        {
            try
            {
                var coursFromDb = await context.Courses.Include(x => x.StudentUsers).FirstOrDefaultAsync(x => x.CourseId == courseId);

                if (coursFromDb is not null && (coursFromDb.StudentUsers.Any(x => x.Id == userId)))
                {
                    var userForDelete = coursFromDb.StudentUsers.FirstOrDefault(x => x.Id == userId);
                    if (userForDelete is not null)
                        coursFromDb.StudentUsers.Remove(userForDelete);

                    await context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            try
            {
                if (course != null)
                {
                    Course courseToUpdate = await context.Courses.FindAsync(course.CourseId);

                    if (courseToUpdate is null)
                        return false;

                    courseToUpdate.CourseName = course.CourseName;
                    courseToUpdate.Duration = course.Duration;
                    if (course.TeacherUserId != null)
                        courseToUpdate.TeacherUserId = course.TeacherUserId;
                    if (course.StudentUsers != null)
                    {
                        courseToUpdate.StudentUsers = course.StudentUsers;
                    }
                    if (course.Schedules != null)
                    {
                        courseToUpdate.Schedules = course.Schedules;

                    }

                    await context.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public async Task<bool> UpdateCourseAsync(Course course, string id)
        {
            try
            {
                if (course != null)
                {
                    Course courseToUpdate = await context.Courses.Include(x => x.StudentUsers).FirstOrDefaultAsync(x => x.CourseId == course.CourseId);
                    if (courseToUpdate is null)
                        return false;

                    StudentUser studentFromDb = await context.StudentUsers.FindAsync(id);
                    if (studentFromDb is null)
                        return false;

                    //courseToUpdate.StudentUsers = new List<StudentUser>();

                    courseToUpdate.CourseName = course.CourseName;
                    courseToUpdate.Duration = course.Duration;
                    if (!courseToUpdate.StudentUsers.Any(x => x.Id == id))
                        courseToUpdate.StudentUsers.Add(studentFromDb);

                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public async Task<bool> UpdateScheduleAsync(Schedule schedule)
        {
            try
            {
                if (schedule != null)
                {
                    Schedule scheduleToUpdate = await context.Schedules.FindAsync(schedule.ScheduleId);

                    if (scheduleToUpdate is null)
                        return false;

                    scheduleToUpdate.DayOfWeek = schedule.DayOfWeek;
                    scheduleToUpdate.StartTime = schedule.StartTime;
                    scheduleToUpdate.EndTime = schedule.EndTime;
                    scheduleToUpdate.CourseId = schedule.CourseId;

                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
