using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC.COM.Controllers
{
    public class CHATBOTController : Controller
    {
        // GET: CHATBOTController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CHATBOTController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CHATBOTController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHATBOTController/Create
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

        // GET: CHATBOTController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CHATBOTController/Edit/5
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

        // GET: CHATBOTController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CHATBOTController/Delete/5
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
