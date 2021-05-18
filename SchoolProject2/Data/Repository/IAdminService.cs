using Microsoft.AspNetCore.Identity;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Data.Repository
{
    public interface IAdminService
    {
        Task<IEnumerable<StudentUser>> GetAllStudents();
        Task<bool> AddStudent(StudentUser student);
        Task<bool> DeleteStudent(string id);
        Task<bool> UpdateStudent(string id, string newName, string newRole);
        Task<StudentUser> GetStudent(string id);
        Task<IdentityRole> GetUserRoleOrNullAsync(IdentityUser user);

        Task<List<IdentityRole>> GetAllRolesAsync();
        Task<string> GetUserRoleOrNullAsync(string userId);

        ////Teacher////
        Task<IEnumerable<TeacherUser>> GetAllTeachers();
        Task<bool> AddTeacher(TeacherUser teacher);
        Task<bool> DeleteTeacher(string id);
        Task<bool> UpdateTeacher();

        ////Course////
        Task<IEnumerable<Course>> GetAllCourses();
        bool AddCourse(Course course);
        Task<bool> DeleteCourse(int id);
        Task<bool> UpdateCourseAsync(Course course);
        Task<Course> GetCourseByIdOrNullAsync(int id);

        //Schedule        
        Task<IEnumerable<Schedule>> GetAllSchedules();
        bool AddSchedule(Schedule schedule);
        Task<bool> DeleteSchedule(int id);
        Task<bool> UpdateSchedule(Course course);
    }
}
