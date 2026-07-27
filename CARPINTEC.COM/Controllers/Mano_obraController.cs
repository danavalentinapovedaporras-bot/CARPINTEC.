using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class Mano_obraController : Controller
    {
        // GET: Mano_obraController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mano_obraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mano_obraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mano_obraController/Create
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

        // GET: Mano_obraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mano_obraController/Edit/5
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

        // GET: Mano_obraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mano_obraController/Delete/5
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
