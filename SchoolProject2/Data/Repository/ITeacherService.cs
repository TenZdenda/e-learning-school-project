using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Data.Repository
{
    public interface ITeacherService
    {
        Task<IEnumerable<StudentUser>> GetAllStudents();
        Task<bool> AddStudent(StudentUser student);
        Task<StudentUser> GetStudent(string id);

        Task<IEnumerable<Course>> GetAllCourses();
        bool AddCourse(Course course);
        Task<bool> DeleteCourse(int id);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course, string id);
        Task<Course> GetCourseByIdOrNullAsync(int id);
        Task<Course> GetCourseAndStudentByIdAsync(int id);
        Task<bool> RemoveUserFromCourseAsync(string userId, int courseId);

        Task<IEnumerable<Schedule>> GetAllSchedules();
        Task<Schedule> GetScheduleByIdOrNullAsync(int id);
        bool AddSchedule(Schedule schedule);
        Task<bool> DeleteSchedule(int id);
        Task<bool> UpdateScheduleAsync(Schedule schedule);
    }
}
