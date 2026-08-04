using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class NuevoProveedorController : Controller
    {
        // GET: NuevoProveedorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NuevoProveedorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NuevoProveedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NuevoProveedorController/Create
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

        // GET: NuevoProveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NuevoProveedorController/Edit/5
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

        // GET: NuevoProveedorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NuevoProveedorController/Delete/5
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
