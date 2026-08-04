using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CARPINTEC_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
    }
}
