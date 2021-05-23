
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
////using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using SchoolProject2.Data;
//using SchoolProject2.Data.EFRepository;
//using SchoolProject2.Data.Repository;
//using SchoolProject2.Models;
//using System.Linq;
//using Xunit;
//using Xunit.Sdk;

//namespace SchoolProject2xUnitTest.Unit_Test
//{    
//    [TestClass]
//    public class CreateCourseUnitTest
//    {
//        [TestMethod]
//        public void CreateCourse_via_context()
//        {
//            //Arrange
//            var mockSet = new Mock<DbSet<Course>>();
//            //mockSet.As<IQueryable<Course>>().Setup(m => m).Returns();
//            //mockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(data.Expression);

//            var mockContext = new Mock<ApplicationDbContext>();
//            mockContext.Setup(m => m.Courses).Returns(mockSet.Object);
//            //mockContext.Setup(repo => repo.Courses).Verifiable();

//            //Act
//            var service = new EFAdminService(mockContext.Object);
//            var course = new Course() { CourseName = "xxx", Duration = 300 };
//            service.AddCourse(course);

//            //Assert
//            mockSet.Verify(m => m.Add(It.IsAny<Course>()), Times.Once());
//            mockContext.Verify(m => m.SaveChanges(), Times.Once());
//        }
//        //[Fact]
//        //public void OnPost_InValidState()
//        //{
//        //    // Arrange
//        //    var mockRepo = new Mock<IAdminService>();
//        //    var createmodel = new CreateCourseModel(mockRepo.Object);
//        //    createmodel.ModelState.AddModelError("key1", "The Text field is required.");

//        //    // Act
//        //    var result = createmodel.OnPost();

//        //    // Assert
//        //    Assert.IsNotType<PageResult>(result);
//        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
//        //    Assert.IsType<SerializableError>(badRequestResult.Value);
//        //}


//        //private List<Course> GetTestCourses()
//        //{
//        //    var courses = new List<Course>();
//        //    courses.Add(new Course()
//        //    {
//        //        CourseName = "Danish102",
//        //        Duration = 300
//        //    });
//        //    courses.Add(new Course()
//        //    {
//        //        CourseName = "English101",
//        //        Duration = 600
//        //    });
//        //    courses.Add(new Course()
//        //    {
//        //        CourseName = "Russian304",
//        //        Duration = 900
//        //    });
//        //    return courses;
//        //}

//        //[Fact]
//        //public void CreateCourse_Post_ReturnsABoolAndAddsCourse_WhenModelStateIsValid()
//        //{
//        //    // Arrange

//        //    var mockRepo = new Mock<EFAdminService>();

//        //    //mockRepo.Setup(repo => repo.AddCourse(It.IsAny<Course>())).Verifiable();

//        //    var course = new Course() { CourseName = "Danish102", Duration = 300 };
//        //    Console.WriteLine(mockRepo.Object);

//        //    var createmodel = new CreateCourseModel(mockRepo.Object);

//        //    createmodel.Course = course;

//        //    // Act
//        //    var result = createmodel.OnPost();

//        //    // Assert
//        //    var redirectToActionResult = Assert.IsType<RedirectToPageResult>(result);
//        //    Assert.Equal("AllCourses", redirectToActionResult.PageName);
//        //    mockRepo.Verify((e) => e.AddCourse(course), Times.Once);

//        //}
//    }
//}
