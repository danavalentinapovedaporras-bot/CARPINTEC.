using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class CotizacionesController : Controller
    {
        // GET: CotizacionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CotizacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CotizacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CotizacionesController/Create
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

        // GET: CotizacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CotizacionesController/Edit/5
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

        // GET: CotizacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CotizacionesController/Delete/5
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
