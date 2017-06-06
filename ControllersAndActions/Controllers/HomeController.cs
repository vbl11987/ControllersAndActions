using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("SimpleForm");

        //This is a way to obtain data from the Form directly using the Form property
        //of the HttpRequest class.
        public ViewResult ReceiveForm() {
            var name = Request.Form["name"];
            var city = Request.Form["city"];
            return View("Result", $"{name} lives in {city}");
        }
        //Obtaining data from the Form using parametres
        //A better aproach and better for unit test because parameters are C# regular parameters
        //we don't require context objects to be mocked 
        [HttpPost]
        public RedirectToActionResult ReceiveForm(string name, string city) {
            TempData["name"] = name;
            TempData["city"] = city;
            return RedirectToAction(nameof(Data));
        }

        public ViewResult Data() {
            string name = TempData["name"] as string;
            string city = TempData["city"] as string;
            return View($"Result", $"{name} lives in {city}");
        }

        //Creating manually the response for the user
        public void ReceiveFormManual(string name, string city){
            Response.StatusCode = 200;
            Response.ContentType = "text/html";
            byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} lives in {city}</body></html>");
            Response.Body.WriteAsync(content, 0, content.Length);
        }
        //Using the CustomHtmlResult to create the response to the user
        public IActionResult ReceiveFormCustom(string name, string city) =>
            new CustomHtmlResult {
                Content = $"{name} lives in {city}"
            };
    }
}
