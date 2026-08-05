using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class RegistroController : Controller
    {
        private readonly CarpintecContext _context;

        public RegistroController(CarpintecContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(Usuario usuario, string confirmarPassword)
        {
            if (!ModelState.IsValid)
                return View("Index", usuario);

            // Verificar si el correo ya existe
            if (_context.Usuarios.Any(u => u.Correo == usuario.Correo))
            {
                TempData["Error"] = "El correo ya está registrado.";
                return View("Index", usuario);
            }

            // Verificar contraseñas
            if (usuario.Contraseña != confirmarPassword)
            {
                TempData["Error"] = "Las contraseñas no coinciden.";
                return View("Index", usuario);
            }

            // Valores por defecto
            usuario.Rol = "Cliente";
            usuario.Estado = "Activo";

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            TempData["Success"] = "Cuenta creada correctamente.";

            return RedirectToAction("Index", "Login");
        }
    }
}