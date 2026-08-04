using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class ConfiguracionClienteController : Controller
    {
        // GET: ConfiguracionClienteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConfiguracionClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConfiguracionClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracionClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConfiguracionClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConfiguracionClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConfiguracionClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConfiguracionClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
