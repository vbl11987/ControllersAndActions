using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void ModelObjectType(){
            //Arrange
            ExampleController controller = new ExampleController();

            //Act
            ViewResult result = controller.IndexStronglyTyped();

            //Assert
            Assert.IsType<System.DateTime>(result.ViewData.Model);
        }

        [Fact]
        public void CheckViewBag(){
            //Arrange
            ExampleController controller = new ExampleController();

            //Act
            ViewResult result = controller.IndexViewBag();

            //Assert
            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
            Assert.IsType<System.DateTime>(result.ViewData["Date"]);
        }

        [Fact]
        public void Redirection(){
            //Arrange
            ExampleController controller = new ExampleController();

            //Act
            RedirectResult result = controller.RedirectPermanent();

            //Assert
            Assert.Equal("/Example/Index", result.Url);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void RedirectionUsingRoute(){
            //Arrange
            ExampleController controller = new ExampleController();

            //Act
            RedirectToRouteResult result = controller.RedirectWithRoute();

            //Assert
            Assert.False(result.Permanent);
            Assert.Equal("Example", result.RouteValues["controller"]);
            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("MyID", result.RouteValues["ID"]);
        }

        [Fact]
        public void RedirectionUsingRedirectionActionResult(){
            //Arrange
            ExampleController controller = new ExampleController();

            //Act
            RedirectToActionResult result = controller.RedirectToActionSameController();

            //Assert
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void JsonActionMethod(){
            //Arrange
            ExampleController controller = new ExampleController();

            //Act
            JsonResult result = controller.IndexJsonReturn();

            //Assert
            Assert.Equal(new[] {"Alice", "Bob", "Joe"}, result.Value);
        }

        [Fact]
        public void NotFoundActionMethod(){
            //Arrange
            ExampleController controller = new ExampleController();

            //Act
            StatusCodeResult result = controller.IndexUsingNotFound();

            //Assert
            Assert.Equal(404, result.StatusCode);
        }
    }
}