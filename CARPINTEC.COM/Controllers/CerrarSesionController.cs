using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class CerrarSesionController : Controller
    {
        // GET: CerrarSesionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CerrarSesionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CerrarSesionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CerrarSesionController/Create
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

        // GET: CerrarSesionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CerrarSesionController/Edit/5
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

        // GET: CerrarSesionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CerrarSesionController/Delete/5
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
