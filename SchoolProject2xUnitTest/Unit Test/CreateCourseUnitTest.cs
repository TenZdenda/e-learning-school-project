using SchoolProject2.Data;
using SchoolProject2.Data.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SchoolProject2.Models;
using Moq;
using SchoolProject2.Data.Repository;
using SchoolProject2.Areas.Admin.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProject2xUnitTest.Unit_Test
{
    public class CreateCourseUnitTest
    {
        //[Fact]
        //public void OnPost_InValidState()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IAdminService>();
        //    var createmodel = new CreateCourseModel(mockRepo.Object);
        //    createmodel.ModelState.AddModelError("key1", "The Text field is required.");

        //    // Act
        //    var result = createmodel.OnPost();

        //    // Assert
        //    Assert.IsNotType<PageResult>(result);
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        //    Assert.IsType<SerializableError>(badRequestResult.Value);
        //}


        //private List<Course> GetTestCourses()
        //{
        //    var courses = new List<Course>();
        //    courses.Add(new Course()
        //    {
        //        CourseName = "Danish102",
        //        Duration = 300
        //    });
        //    courses.Add(new Course()
        //    {
        //        CourseName = "English101",
        //        Duration = 600
        //    });
        //    courses.Add(new Course()
        //    {
        //        CourseName = "Russian304",
        //        Duration = 900
        //    });
        //    return courses;
        //}

        [Fact]
        public void CreateCourse_Post_ReturnsABoolAndAddsCourse_WhenModelStateIsValid()
        {
            // Arrange

            var mockRepo = new Mock<IAdminService>();

            mockRepo.Setup(repo => repo.AddCourse(It.IsAny<Course>())).Verifiable();

            var @course = new Course() { CourseName = "Danish102", Duration = 300 };
            Console.WriteLine(mockRepo.Object);

            var createmodel = new CreateCourseModel(mockRepo.Object);

            createmodel.Course = @course;

            // Act
            var result = createmodel.OnPost();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal("AllCourses", redirectToActionResult.PageName);
            mockRepo.Verify((e) => e.AddCourse(@course), Times.Once);

        }
    }
}
