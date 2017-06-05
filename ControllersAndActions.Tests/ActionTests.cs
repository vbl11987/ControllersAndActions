using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void ViewSelected(){
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.ReceiveForm("Boris", "Miami");

            //Assert
            Assert.Equal("Result", result.ViewName);
        }
    }
}