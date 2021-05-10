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
        Task<bool> UpdateStudent(StudentUser updateStudent);
        Task<StudentUser> GetStudent(string id);
        Task<IdentityRole> GetUserRoleOrNullAsync(IdentityUser user);

        ////Teacher////
        Task<IEnumerable<TeacherUser>> GetAllTeachers();
        Task<bool> AddTeacher(TeacherUser teacher);
        Task<bool> DeleteTeacher(string id);
        Task<bool> UpdateTeacher();

        ////Course////
        Task<IEnumerable<Course>> GetAllCourses();
        Task<bool> AddCourse(Course course);
        Task<bool> DeleteCourse(int id);
        Task<bool> UpdateCourse(Course course);

    }
}
