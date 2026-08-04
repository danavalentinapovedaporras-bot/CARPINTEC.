using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class CatalogosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}