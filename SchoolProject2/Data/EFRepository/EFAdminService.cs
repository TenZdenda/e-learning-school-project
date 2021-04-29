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
        public IEnumerable<StudentUser> GetAllStudents()
        {
            return context.StudentUsers ;
        }

        public IEnumerable<TeacherUser> GetAllTeachers()
        {
            return context.TeacherUsers;
        }
    }
}
