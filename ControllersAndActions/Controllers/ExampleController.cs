using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index() => View(DateTime.Now);

        public ViewResult IndexViewBag(){
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public ViewResult IndexStronglyTyped() => View(DateTime.Now);

        //Without casting the string Hello World to object the framework will try to find a view
        //called Hello World
        public ViewResult Result() => View((object)"Hello World");

        
        public RedirectResult Redirect() => Redirect("/Example/Index");

        //Permanent redirection
        public RedirectResult RedirectPermanent() => RedirectPermanent("/Example/Index");

        public RedirectToRouteResult RedirectWithRoute() => 
            RedirectToRoute(new { controller = "Example", action = "Index", ID = "MyID"});

        //Redirecting to an action on the same controlller
        public RedirectToActionResult RedirectToActionSameController() => RedirectToAction("Index");
        //redirecting to an action on other controller
        public RedirectToActionResult RedirectToActionOtherController() => RedirectToActionPermanent("Index", "Home");

        //Returning a JSON
        public JsonResult IndexJsonReturn() => Json(new[] {"Alice", "Bob", "Joe"});

        //Manually creating a JSON result
        public ContentResult IndexJsonManually() => 
            Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");
        
        //Returning an ObjectResult
        public ObjectResult IndexJsonObjectResult() =>
            Ok(new string[] { "Alice", "Bob", "Joe" });

        //Returning a file
        public VirtualFileResult IndexReturningBootstrapFile() =>
            File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");

        //Returning a 404 Not Found status to the client
        public StatusCodeResult IndexStatusCodeNotFound() => StatusCode(StatusCodes.Status404NotFound);

        //More elegant way to send a 404 Not Found status to the client
        public StatusCodeResult IndexUsingNotFound() => NotFound();
    }
}