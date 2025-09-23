using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApp.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersWebApi_Module3WithMoq.Models;

namespace CreateControllerTests;
[TestClass]
public class CreateUnitTest
{
  
// comment
    [TestMethod]
    public async Task Create_ReturnsCreatedAtAction_WhenModelIsValid()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        var controller = new UsersController(mockRepo.Object);
        var newUser = new User { Username = "Mohammed", Email = "moal@test.dk" };

        mockRepo.Setup(r => r.AddAsync(It.IsAny<User>()))
            .Returns(Task.CompletedTask)
            .Verifiable();

        // Act
        var result = await controller.Create(newUser);

        // Assert
        var createdAt = result.Result as CreatedAtActionResult;
        Assert.IsNotNull(createdAt);
        var returnValue = createdAt.Value as User;
        Assert.IsNotNull(returnValue);
        Assert.AreEqual("Charlie", returnValue.Username);

        mockRepo.Verify();
    }
}
