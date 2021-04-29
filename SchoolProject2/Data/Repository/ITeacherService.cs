using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject2.Data.Repository
{
    interface ITeacherService
    {
        List<StudentUser> GetAllStudents();
    }
}
