using CARPINTEC_App.Models;
using CARPINTEC_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CARPINTEC_App.Controllers
{
    public class VentasController : Controller
    {
        private readonly CarpintecContext _context;

        public VentasController(CarpintecContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Venta venta)
        {
            if (ModelState.IsValid)
            {
                venta.Estado = "Pendiente"; // Estado por defecto
                _context.Ventas.Add(venta);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }
        public IActionResult Index()
        {
            // Consultamos la tabla Ventas del contexto
            var ventasList = _context.Ventas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdPedidoNavigation)
                .ToList();

            // --- CÁLCULOS PARA LAS TARJETAS BENTO ---
            decimal ventasTotales = ventasList
                .Where(v => v.Estado != "Anulada")
                .Sum(v => v.Total);
            ViewBag.VentasTotalesMes = ventasTotales.ToString("N2");

            var pendientes = ventasList.Where(v => v.Estado == "Pendiente").ToList();
            ViewBag.CantidadPendientes = pendientes.Count;
            ViewBag.ValorPendientesFormatted = pendientes.Sum(v => v.Total).ToString("N2");

            decimal totalRecaudado = ventasList
                .Where(v => v.Estado == "Pagada")
                .Sum(v => v.Total);
            ViewBag.TotalRecaudadoFormatted = totalRecaudado.ToString("N2");

            ViewBag.CantidadProximos = pendientes.Count;
            ViewBag.SiguienteVencimientoFecha = "Al día";

            return View(ventasList);
        }

        public IActionResult VerFactura(int id)
        {
            var venta = _context.Ventas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdPedidoNavigation)
                .FirstOrDefault(v => v.IdVenta == id);

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }
    }
}