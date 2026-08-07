using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class Mi_PedidoController : Controller
    {
        // GET: Mi_PedidoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mi_PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mi_PedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mi_PedidoController/Create
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

        // GET: Mi_PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mi_PedidoController/Edit/5
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

        // GET: Mi_PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mi_PedidoController/Delete/5
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
