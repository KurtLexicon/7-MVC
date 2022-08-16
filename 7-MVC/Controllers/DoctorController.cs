using Microsoft.AspNetCore.Mvc;
using _7_MVC.Models;

namespace _7_MVC.Controllers {
    public class DoctorController : Controller {
        public IActionResult FeverCheck(string temperature) {
            string msg = Models.FeverCheck.CheckTemperature(temperature);
            ViewData["Message"] = msg;
            ViewBag.Message = msg;
            return View();
        }
    }
}
