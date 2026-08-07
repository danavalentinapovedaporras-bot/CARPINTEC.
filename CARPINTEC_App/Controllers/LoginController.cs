using CARPINTEC_App.Data;
using Microsoft.AspNetCore.Mvc;

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
        return RedirectToAction("Index", "Login");
    }


    [HttpPost]
    public IActionResult Ingresar(string username, string password, string rol = "empleado")
    {
        // 1. Validar que no envíe campos vacíos
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            TempData["Error"] = "Por favor ingrese usuario y contraseña";
            return RedirectToAction("Index");
        }

        try
        {
            // 2. Buscar al usuario en la Base de Datos (sirve para Admin, Cliente o Empleado)
            var usuario = _context.Usuarios
                .FirstOrDefault(u =>
                    (u.Correo.ToLower() == username.ToLower() ||
                     u.Nombre.ToLower() == username.ToLower()) &&
                     u.Estado == "Activo");

            // Si el usuario no existe
            if (usuario == null)
            {
                TempData["Error"] = "Usuario o contraseña incorrectos";
                return RedirectToAction("Index");
            }

            // Validar contraseña
            if (usuario.Contraseña != password)
            {
                TempData["Error"] = "Usuario o contraseña incorrectos";
                return RedirectToAction("Index");
            }

            // Guardar datos de sesión
            HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
            HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
            HttpContext.Session.SetString("Rol", usuario.Rol ?? "Usuario");

            // Redireccionar según el rol
            string rolBD = (usuario.Rol ?? "").Trim().ToLower();

            if (rolBD == "cliente")
            {
                return RedirectToAction("Index", "DashboardCliente");
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Error al procesar la solicitud";
            return RedirectToAction("Index");
        }
    }
}