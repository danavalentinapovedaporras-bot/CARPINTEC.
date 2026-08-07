using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class LoginController : Controller
    {
        private readonly CarpintecContext _context;

        public LoginController(CarpintecContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Ingresar(string username, string password)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                TempData["Error"] = "Por favor ingrese usuario y contraseña.";
                return RedirectToAction("Index");
            }

            try
            {
                // Buscar usuario
                var usuario = _context.Usuarios.FirstOrDefault(u =>
                    (u.Correo.ToLower() == username.ToLower() ||
                     u.Nombre.ToLower() == username.ToLower()) &&
                    u.Estado == "Activo");

                if (usuario == null)
                {
                    TempData["Error"] = "Usuario o contraseña incorrectos.";
                    return RedirectToAction("Index");
                }

                // Validar contraseña
                bool acceso = false;

                // Contraseña encriptada
                if (!string.IsNullOrEmpty(usuario.Contraseña) &&
                    usuario.Contraseña.StartsWith("AQAAAA"))
                {
                    var hasher = new PasswordHasher<Usuario>();

                    var resultado = hasher.VerifyHashedPassword(
                        usuario,
                        usuario.Contraseña,
                        password);

                    acceso = resultado == PasswordVerificationResult.Success;
                }
                else
                {
                    // Contraseña antigua (texto plano)
                    acceso = usuario.Contraseña == password;
                }

                if (!acceso)
                {
                    TempData["Error"] = "Usuario o contraseña incorrectos.";
                    return RedirectToAction("Index");
                }

                // Guardar sesión
                HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre + " " + usuario.Apellido);
                HttpContext.Session.SetString("Rol", usuario.Rol ?? "Usuario");

                // Redireccionar según el rol
                string rol = (usuario.Rol ?? "").Trim().ToLower();

                switch (rol)
                {
                    case "cliente":
                        return RedirectToAction("Index", "DashboardCliente");

                    case "administrador":
                        return RedirectToAction("Index", "Dashboard");

                    case "empleado":
                        return RedirectToAction("Index", "Dashboard");

                    default:
                        return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}