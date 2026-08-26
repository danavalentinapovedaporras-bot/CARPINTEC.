using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CARPINTEC_App.Controllers
{
    [Authorize]
    public class PQRController : Controller
    {
        private readonly CarpintecContext _context;

        public PQRController(CarpintecContext context)
        {
            _context = context;
        }


        // LISTADO DE PQR
        public async Task<IActionResult> Index()
        {
            var listaPqr = await _context.Pqrs
                .Include(p => p.IdClienteNavigation)
                .OrderByDescending(p => p.FechaRegistro)
                .ToListAsync();


            // Estadísticas
            ViewBag.Pendientes = listaPqr.Count(p => p.Estado == "Pendiente");
            ViewBag.EnProceso = listaPqr.Count(p => p.Estado == "En proceso");
            ViewBag.Respondidas = listaPqr.Count(p => p.Estado == "Respondida");
            ViewBag.Cerradas = listaPqr.Count(p => p.Estado == "Cerrada");


            // Clientes para el modal de crear PQR
            ViewBag.Clientes = await _context.Clientes
                .Where(c => c.Estado == "Activo")
                .ToListAsync();


            return View(listaPqr);
        }

        // VER DETALLE DE PQR
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
        // GUARDAR NUEVA PQR DESDE EL MODAL DEL INDEX
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pqr pqr)
        {

            Console.WriteLine("ENTRÓ AL CREATE");
            Console.WriteLine("Cliente: " + pqr.IdCliente);
            Console.WriteLine("Asunto: " + pqr.Asunto);
            Console.WriteLine("Descripcion: " + pqr.Descripcion);


            pqr.CodigoPqr = "PQR-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            pqr.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);

            pqr.Estado = "Pendiente";


            _context.Pqrs.Add(pqr);

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }


        // RESPONDER PQR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Responder(int id, string respuesta, string estado)
        {

            var pqr = await _context.Pqrs
                .FirstOrDefaultAsync(p => p.IdPqr == id);


            if (pqr == null)
            {
                return NotFound();
            }


            pqr.Respuesta = respuesta;
            pqr.Estado = estado;
            pqr.FechaRespuesta = DateOnly.FromDateTime(DateTime.Now);


            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }



        // CAMBIAR ESTADO DE PQR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id, string estado)
        {

            var pqr = await _context.Pqrs.FindAsync(id);


            if (pqr == null)
            {
                return NotFound();
            }


            pqr.Estado = estado;


            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

    }
}