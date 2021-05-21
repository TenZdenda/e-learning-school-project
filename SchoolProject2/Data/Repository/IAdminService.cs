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
        Task<bool> UpdateUserRole(string id, string newName, string newRole);
        Task<StudentUser> GetStudent(string id);
        Task<IdentityRole> GetUserRoleOrNullAsync(IdentityUser user);

        Task<List<IdentityRole>> GetAllRolesAsync();
        Task<string> GetUserRoleOrNullAsync(string userId);

        ////Teacher////
        Task<IEnumerable<TeacherUser>> GetAllTeachers();
        Task<bool> AddTeacher(TeacherUser teacher);
        Task<bool> DeleteTeacher(string id);

        ////Course////
        Task<IEnumerable<Course>> GetAllCourses();
        bool AddCourse(Course course);
        Task<bool> DeleteCourse(int id);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course, string id);
        Task<Course> GetCourseByIdOrNullAsync(int id);
        Task<Course> GetCourseAndStudentByIdAsync(int id);

        //Schedule        
        Task<IEnumerable<Schedule>> GetAllSchedules();
        Task<Schedule> GetScheduleByIdOrNullAsync(int id);
        bool AddSchedule(Schedule schedule);
        Task<bool> DeleteSchedule(int id);
        Task<bool> UpdateScheduleAsync(Schedule schedule);
    }
}
