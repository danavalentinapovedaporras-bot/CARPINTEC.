using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class MisProductosController : Controller
    {
        // GET: MisProductosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MisProductosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MisProductosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MisProductosController/Create
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

        // GET: MisProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MisProductosController/Edit/5
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

        // GET: MisProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MisProductosController/Delete/5
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
