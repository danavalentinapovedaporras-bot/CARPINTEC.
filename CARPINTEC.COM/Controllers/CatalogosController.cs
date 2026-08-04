using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class CatalogosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}