using CARPINTEC.COM.Data;
using CARPINTEC.COM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CARPINTEC.COM.Controllers
{
    public class VentasController : Controller
    {
        // Aquí va el contexto
        private readonly CarpintecContext _context;

        // Aquí va el constructor
        public VentasController(CarpintecContext context)
        {
            _context = context;
        }

        // Después siguen los métodos
      public IActionResult Index()
{
    var facturas = _context.Facturas.ToList();
    return View(facturas);
}



public IActionResult VerFactura(int id)
    {
        var factura = _context.Facturas
            .Include(f => f.DetallesFactura)
                .ThenInclude(d => d.Producto)
            .FirstOrDefault(f => f.IdFactura == id);

        if (factura == null)
        {
            return NotFound();
        }

        return View(factura);
    }
}
}