using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CARPINTEC_App.Controllers
{
    public class RecuperarController : Controller
    {
        private readonly CarpintecContext _context;

        public RecuperarController(CarpintecContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarCorreo(string correo)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(x => x.Correo == correo);

            if (usuario == null)
            {
                TempData["Error"] = "El correo no está registrado.";
                return RedirectToAction("Index");
            }

            HttpContext.Session.SetInt32("UsuarioRecuperacion", usuario.IdUsuario);

            return RedirectToAction("NuevaContraseña");
        }

        [HttpGet]
        public IActionResult NuevaContraseña()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarNuevaContraseña(string password, string confirmarPassword)
        {
            if (password != confirmarPassword)
            {
                TempData["Error"] = "Las contraseñas no coinciden.";
                return View("NuevaContraseña");
            }

            int? id = HttpContext.Session.GetInt32("UsuarioRecuperacion");

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var usuario = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);

            if (usuario == null)
            {
                return RedirectToAction("Index");
            }

            var hasher = new PasswordHasher<Usuario>();

            usuario.Contraseña = hasher.HashPassword(usuario, password);

            _context.SaveChanges();

            HttpContext.Session.Remove("UsuarioRecuperacion");

            TempData["Success"] = "La contraseña fue cambiada correctamente.";

            return RedirectToAction("Index", "Login");
        }
    }
}