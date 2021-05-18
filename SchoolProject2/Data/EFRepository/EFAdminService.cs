﻿using Microsoft.AspNetCore.Identity;
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

    public class EFAdminService : IAdminService
    {
        ApplicationDbContext context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EFAdminService(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            context = db;
            _roleManager = roleManager;
        }


        public async Task<bool> AddStudent(StudentUser student)
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

        public async Task<IEnumerable<StudentUser>> GetAllStudents()
        {
            var result = await context.StudentUsers.ToListAsync();
            return result;

        }


        public async Task<bool> DeleteStudent(string id)
        {
            if (id == null || id.Trim().Length == 0)
                return false;

            var userFromDb = await context.StudentUsers.FindAsync(id);

            if (userFromDb == null)
                return false;

            context.Remove(userFromDb);

            await context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateStudent(string id, string newName, string newRole)
        {
            var userFromDb = await context.Users.FindAsync(id);

            if (userFromDb is null)
                return false;

            var type = userFromDb.GetType().Name;

            switch (type)
            {
                case nameof(StudentUser):
                    var castedStudent = userFromDb as StudentUser;
                    castedStudent.Name = newName;
                    var currentRoleName = await GetUserRoleOrNullAsync(castedStudent.Id);
                    if (newRole != currentRoleName)
                    {
                        await _userManager.RemoveFromRoleAsync(castedStudent, currentRoleName);
                        await _userManager.AddToRoleAsync(castedStudent, newRole);
                    }
                    await context.SaveChangesAsync();
                    return true;
                case nameof(AdminUser):
                    var castedAdmin = userFromDb as AdminUser;
                    castedAdmin.Name = newName;
                    var currentRoleAdmin = await GetUserRoleOrNullAsync(castedAdmin.Id);
                    if (newRole != currentRoleAdmin)
                    {
                        await _userManager.RemoveFromRoleAsync(castedAdmin, currentRoleAdmin);
                        await _userManager.AddToRoleAsync(castedAdmin, currentRoleAdmin);
                    }
                    await context.SaveChangesAsync();
                    return true;
                case nameof(TeacherUser):
                    var castedTeacher = userFromDb as TeacherUser;
                    castedTeacher.Name = newName;
                    var currentRoleTeacher = await GetUserRoleOrNullAsync(castedTeacher.Id);
                    if (newRole != currentRoleTeacher)
                    {
                        await _userManager.RemoveFromRoleAsync(castedTeacher, currentRoleTeacher);
                        await _userManager.AddToRoleAsync(castedTeacher, currentRoleTeacher);
                    }
                    await context.SaveChangesAsync();
                    return true;
            }

            return false;
        }

        public async Task<IdentityRole> GetUserRoleOrNullAsync(IdentityUser user)
        {
            foreach (var role in _roleManager.Roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    var returnedRole = new IdentityRole(role.Name);
                    return returnedRole;
                }
            }
            return null;
        }

        public async Task<StudentUser> GetStudent(string id)
        {
            var result = await context.StudentUsers.FindAsync(id);
            return result;
        }


        /// 
        /// TEACHERS
        /// 


        public async Task<IEnumerable<TeacherUser>> GetAllTeachers()
        {
            var result = await context.TeacherUsers.ToListAsync();
            return result;
        }

        public async Task<bool> AddTeacher(TeacherUser teacher)
        {
            if (teacher != null)
            {
                var user = new TeacherUser
                {
                    UserName = teacher.Email,
                    Email = teacher.Email,
                    Name = teacher.Name,
                    PhoneNumber = teacher.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, teacher.Password);

                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(SD.TeacherUser))
                        await _roleManager.CreateAsync(new IdentityRole(SD.TeacherUser));

                    await _userManager.AddToRoleAsync(user, SD.TeacherUser);
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> DeleteTeacher(string id)
        {
            if (id == null || id.Trim().Length == 0)
                return false;

            var userFromDb = await context.TeacherUsers.FindAsync(id);

            if (userFromDb == null)
                return false;

            context.Remove(userFromDb);

            await context.SaveChangesAsync();
            return true;
        }

        public Task<bool> UpdateTeacher()
        {
            throw new NotImplementedException();
        }

        // COURSES
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var result = await context.Courses.ToListAsync();
            return result;
        }

        public bool AddCourse(Course course)
        {
            if (course != null)
            {
                //course = new Course
                //{
                //    CourseName = course.CourseName,
                //    Duration = course.Duration                   
                //};

                context.Courses.Add(course);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCourse(int id)
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


        public async Task<bool> UpdateCourseAsync(Course course)
        {
            //var result = context.Courses.Where(x=>x.CourseName.Contains();

            //if(result != null)
            //{
            //    result.CourseId = course.CourseId;
            //    result.CourseName = course.CourseName;
            //    result.Duration = course.Duration;
            //    await context.SaveChangesAsync();
            //}
            return true;

            
        }
        public async Task<bool> UpdateCourse(Course course)
        {
            try
            {
                if (course != null)
                {
                    Course courseToUpdate = await context.Courses.FindAsync(course.CourseId);

                    courseToUpdate.CourseName = course.CourseName;
                    courseToUpdate.Duration = course.Duration;
                    courseToUpdate.TeacherUserId = course.TeacherUserId;
                    courseToUpdate.Teacher = course.Teacher;
                    courseToUpdate.Schedules = course.Schedules;

                    context.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public async Task<List<IdentityRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        //UserRoles
        public async Task<string> GetUserRoleOrNullAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            foreach (var role in _roleManager.Roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    return role.Name;
            }
            return null;
        }


        public async Task<bool> GetCourseByIdAsync(int id)
        {
            var result = await context.Courses.FindAsync(id);
            return true;


        }
        //Schedules
        public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            var result = await context.Schedules.Include(s => s.Course).ToListAsync();
            return result;
        }

        public bool AddSchedule(Schedule schedule)
        {
            if (schedule != null)
            {
                //schedule = new Schedule
                //{
                //    DayOfWeek = schedule.DayOfWeek,
                //    Duration = course.Duration
                //};
                
                context.Schedules.Add(schedule);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Task<bool> DeleteSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSchedule(Course course)
        {
            throw new NotImplementedException();

        }


    }
}
