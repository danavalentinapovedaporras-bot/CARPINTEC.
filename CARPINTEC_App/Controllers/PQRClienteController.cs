using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class PQRClienteController : Controller
    {
        // GET: PQRClienteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PQRClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PQRClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PQRClienteController/Create
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

        // GET: PQRClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PQRClienteController/Edit/5
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

        // GET: PQRClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PQRClienteController/Delete/5
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
