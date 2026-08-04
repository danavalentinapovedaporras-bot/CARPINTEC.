using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CARPINTEC_App.Controllers
{
    public class CotizacionesController : Controller
    {
        private readonly CarpintecContext _context;

        public CotizacionesController(CarpintecContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var cotizaciones = await _context.Cotizacions
                .Include(c => c.IdClienteNavigation)
                .ToListAsync();

            return View(cotizaciones);
        }

        // GET: CotizacionesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cotizacion = await _context.Cotizacions
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(c => c.IdCotizacion == id);

            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // GET: CotizacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CotizacionesController/Create
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

        // GET: CotizacionesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cotizacion = await _context.Cotizacions
                .FirstOrDefaultAsync(c => c.IdCotizacion == id);

            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: CotizacionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cotizacion cotizacion)
        {
            if (id != cotizacion.IdCotizacion)
            {
                return NotFound();
            }

            try
            {
                _context.Entry(cotizacion).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }
        // GET: CotizacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CotizacionesController/Delete/5
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
