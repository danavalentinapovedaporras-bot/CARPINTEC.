using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class NuevoPedidoController : Controller
    {
        // GET: NuevoPedidoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NuevoPedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NuevoPedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NuevoPedidoController/Create
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

        // GET: NuevoPedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NuevoPedidoController/Edit/5
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

        // GET: NuevoPedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NuevoPedidoController/Delete/5
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
