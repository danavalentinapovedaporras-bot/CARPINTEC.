using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class MiPerfilController : Controller
    {
        // GET: MiPerfilController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MiPerfilController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MiPerfilController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiPerfilController/Create
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

        // GET: MiPerfilController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MiPerfilController/Edit/5
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

        // GET: MiPerfilController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MiPerfilController/Delete/5
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
