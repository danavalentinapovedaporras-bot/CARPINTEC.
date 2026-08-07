using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class DashboardClienteController : Controller
    {
        // GET: DashboardClienteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashboardClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardClienteController/Create
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

        // GET: DashboardClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardClienteController/Edit/5
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

        // GET: DashboardClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardClienteController/Delete/5
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
