using BlockBusterWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlockBusterWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Colors()
        {
            string[] colors = { "Red", "Blue", "Yellow" };
            ViewBag.Colors = colors;
            return View();
        }

        public IActionResult Cities()
        {
            ViewBag.Cities = new List<string>
            {
                "Tokyo, Japan",
                "Paris, France",
                "New York City, USA",
                "Rome, Italy",
                "Sydney, Australia"
            };

            return View();
        }

        public IActionResult Hobbies()
        {
            ViewBag.Hobbies = new List<string>
            {
                "Hiking",
                "Basketball",
                "Playing Piano",
                "Coding",
                "Traveling"
            };

            return View();
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}