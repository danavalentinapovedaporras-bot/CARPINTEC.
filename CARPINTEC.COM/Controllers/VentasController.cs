using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class Ventas_y_FacturacionController : Controller
    {
        // GET: Ventas_y_FacturacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ventas_y_FacturacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ventas_y_FacturacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ventas_y_FacturacionController/Create
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

        // GET: Ventas_y_FacturacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ventas_y_FacturacionController/Edit/5
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

        // GET: Ventas_y_FacturacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ventas_y_FacturacionController/Delete/5
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
