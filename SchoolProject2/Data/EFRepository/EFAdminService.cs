using Microsoft.AspNetCore.Identity;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Data.EFRepository
{
    public class EFAdminService : IAdminService
    {
        ApplicationDbContext context;

        public EFAdminService(ApplicationDbContext db)
        {
            context = db;
        }

       
        public void AddStudent(StudentUser student)
        {
            if (student != null)
            {
                context.StudentUsers.Add(student);
                context.SaveChanges();
            }
        }

        public IEnumerable<StudentUser> GetAllStudents()
        {
            return context.StudentUsers;
            //return context.AdminUsers.Where(user=>user.UserName=="Vladimir").ToList();
            
        }

        public IEnumerable<TeacherUser> GetAllTeachers()
        {
            return context.TeacherUsers.ToList();
        }

    //    List<StudentUser> IAdminService.GetAllStudents()
    //    {
    //        throw new NotImplementedException();
    //    }
    }
}
