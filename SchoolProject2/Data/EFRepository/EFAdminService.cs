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
                    Name = student.Name
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

        
        public async Task<bool> UpdateStudent(StudentUser updateStudent)
        {
           var result = await context.StudentUsers.FirstOrDefaultAsync(e => e.Id == updateStudent.Id);
            

            if (result != null)
            {
                result.Name = updateStudent.Name;
                result.Email = updateStudent.Email;
            }
            else
                return false;
            

            await context.SaveChangesAsync();
            return true;
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
                    Name = teacher.Name
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
                course = new Course
                {
                    CourseName = course.CourseName,
                    Duration = course.Duration                   
                };
                
                context.Courses.Add(course);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Task<bool> DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
