using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject2.Data;
using SchoolProject2.Data.EFRepository;
using SchoolProject2.Models;
using SchoolProject2_UnitTest.xUnitTestsOfStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolProject2_UnitTest.xUnitTestsOfStudents
{
    public class StudentsUnitTest : EFTestDataServiceOfStudents
    {       
        public StudentsUnitTest() : base(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Filename=Test.db").Options)
        {
            
        }

       // [Fact]
        public async void Add_Student_Test()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                EFAdminService service = new EFAdminService(context);
                StudentUser s5 = new StudentUser() { Id = "S5-rr-4d", Name = "Stud5", Email = "S5@yahoo.com", Password = "Abc+123", ConfirmPassword = "Abc+123", PhoneNumber = "999999" };
                await service.AddStudent(s5);

                Assert.Equal(5, context.StudentUsers.ToList().Count());
                //Assert.True(context.StudentUsers.ToList()[2].Id == "S3");
            }
        }
    }
}
