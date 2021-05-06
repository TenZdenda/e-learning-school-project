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
        IEnumerable<TeacherUser> GetAllTeachers();
        Task<IEnumerable<StudentUser>> GetAllStudents();
        Task<bool> AddStudent(StudentUser student);
        Task<bool> DeleteStudent(string id);
        
    }
}
