using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolProject2.Data;
using SchoolProject2.Data.EFRepository;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject2_UnitTest
{
    [TestClass]
    class AddCourseUnitTest
    {
        [TestMethod]
        public void AddCourse_via_context()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Course>>();
            
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Courses);
            
            //Act
            var service = new EFAdminService(mockContext.Object);
            var course = new Course() { CourseName = "xxxxxx", Duration = 300 };
            service.AddCourse(course);
            Console.WriteLine(service.GetAllCourses());
            Console.ReadKey();

            //Assert
            mockSet.Verify(m => m.Add(It.IsAny<Course>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
