using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Moq;
using SchoolProject2.Data.Repository;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolProject2xUnitTest.Unit_Test
{
    public class IndexUnitTest
    {
    //    private readonly Mock<IAdminService> mockRepo;
    //    private readonly IndexModel indexmodel;
    //    public IndexUnitTest()
    //    {
    //        mockRepo = new Mock<IAdminService>();
    //        //indexmodel = new IndexModel(mockRepo.Object);
    //    }
    //    [Fact]
    //    public void OnGet_Returns_AListOfAllCourses()
    //    {
    //        // Arrange
    //        mockRepo.Setup(mockrepo => mockrepo.GetAllCourses()).Returns(GetTestCourses());

    //        // Act
    //        var result = indexmodel.OnGetAsync();
    //        //List<Course> myList = indexmodel.Courses;

    //        // Assert
    //        Assert.IsAssignableFrom<IActionResult>(result);
    //        var viewResult = Assert.IsType<PageResult>(result);
    //        var actualMessages = Assert.IsType<List<Event>>(myList);
    //        Assert.Equal(2, myList.Count);
    //        Assert.Equal("Test 1", myList[0].Name);
    //        Assert.Equal("Test 2", myList[1].Name);
    //    }

    //    private List<Event> GetTestCourses()
    //    {
    //        var events = new List<Event>();
    //        events.Add(new Event()
    //        {
    //            Id = 1,
    //            Name = "Test 1",
    //            Description = "Test Description",
    //            City = "CPH",
    //            DateTime = new DateTime(2021, 8, 19),

    //        });
    //        events.Add(new Event()
    //        {
    //            Id = 2,
    //            Name = "Test 2",
    //            Description = "Test 2 Description",
    //            City = "Odense",
    //            DateTime = new DateTime(2021, 10, 22),

    //        });
    //        return events;
    //    }

    //    [Fact]
    //    public void FilterCriteria_Null()
    //    {
    //        // Arrange
    //        var mockRepo = new Mock<IEventRepository>();

    //        IndexModel indexmodel = new IndexModel(mockRepo.Object);
    //        string FilterCriteria = "CPH";

    //        // Act
    //        var result = indexmodel.OnGet();

    //        // Assert
    //        Assert.IsAssignableFrom<IActionResult>(result);
    //        var viewResult = Assert.IsType<PageResult>(result);
    //        mockRepo.Verify(m => m.FilterEvents(FilterCriteria), Times.Never);

    //    }

    //    [Fact]
    //    public void FilterCriteria_Not_Null()
    //    {
    //        // Arrange
    //        var mockRepo = new Mock<IEventRepository>();
    //        mockRepo.Setup(mockrepo => mockrepo.GetAllEvents())
    //        .Returns(GetTestEvents()).Verifiable();

    //        IndexModel indexmodel = new IndexModel(mockRepo.Object);
    //        indexmodel.FilterCriteria = "CPH";

    //        // Act
    //        var result = indexmodel.OnGet();
    //        var filtered = indexmodel.Events;

    //        // Assert
    //        Assert.IsAssignableFrom<IActionResult>(result);
    //        mockRepo.VerifyAll();
    //    }
    }
}
