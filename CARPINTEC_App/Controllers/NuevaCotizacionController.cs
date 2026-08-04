using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class NuevaCotizacionController : Controller
    {
        // GET: NuevaCotizacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NuevaCotizacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NuevaCotizacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NuevaCotizacionController/Create
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

        // GET: NuevaCotizacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NuevaCotizacionController/Edit/5
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

        // GET: NuevaCotizacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NuevaCotizacionController/Delete/5
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
