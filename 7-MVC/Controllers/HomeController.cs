using Microsoft.AspNetCore.Mvc;

namespace _7_MVC.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult About() {
            return View();
        }
        public IActionResult Contact() {
            return View();
        }
        public IActionResult Projects() {
            return View();
        }
    }
}
