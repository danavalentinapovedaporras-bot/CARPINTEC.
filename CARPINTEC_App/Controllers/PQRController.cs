using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CARPINTEC_App.Controllers
{
    public class PQRController : Controller
    
    {
        private readonly CarpintecContext _context;

        public PQRController(CarpintecContext context)
        {
            _context = context;
        }
        // GET: PQRController
        public async Task<IActionResult> Index()
        {
            var listaPqr = await _context.Pqrs
                .Include(p => p.IdClienteNavigation)
                .ToListAsync();

            return View(listaPqr);
        }

        // GET: PQRController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var pqr = await _context.Pqrs
                .Include(p => p.IdClienteNavigation)
                .FirstOrDefaultAsync(p => p.IdPqr == id);

            if (pqr == null)
            {
                return NotFound();
            }

            return View(pqr);
        }
        public async Task<IActionResult> Responder(int id)
        {
            var pqr = await _context.Pqrs
                .Include(p => p.IdClienteNavigation)
                .FirstOrDefaultAsync(p => p.IdPqr == id);

            if (pqr == null)
            {
                return NotFound();
            }

            return View(pqr);
        }

        // GET: PQRController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PQRController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Responder(int id, Pqr pqr)
        {
            if (id != pqr.IdPqr)
            {
                return NotFound();
            }

            var pqrDB = await _context.Pqrs.FindAsync(id);

            if (pqrDB == null)
            {
                return NotFound();
            }

            pqrDB.Respuesta = pqr.Respuesta;
            pqrDB.Estado = pqr.Estado;
            pqrDB.FechaRespuesta = DateOnly.FromDateTime(DateTime.Now);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
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

        // GET: PQRController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var pqr = await _context.Pqrs
                .Include(p => p.IdClienteNavigation)
                .FirstOrDefaultAsync(p => p.IdPqr == id);

            if (pqr == null)
            {
                return NotFound();
            }

            return View(pqr);
        }

        // POST: PQRController/Edit/5
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

        // GET: PQRController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PQRController/Delete/5
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
