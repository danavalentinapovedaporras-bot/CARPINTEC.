using CARPINTEC.COM.Data;
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

    [HttpPost]
    public IActionResult Ingresar(string username, string password, string rol = "empleado")
    {
        // Validar que los campos no estén vacíos
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            TempData["Error"] = "Por favor ingrese usuario y contraseña";
            return RedirectToAction("Index");
        }

        try
        {
            // Buscar el usuario en la BD por correo (case-insensitive) o nombre
            var usuario = _context.Usuarios
                .FirstOrDefault(u => (u.Correo.ToLower() == username.ToLower() || u.Nombre.ToLower() == username.ToLower()) && u.Estado == "Activo");

            if (usuario == null)
            {
                // Log para debugging
                Console.WriteLine($"Usuario no encontrado con username: {username}");
                TempData["Error"] = "Usuario o contraseña incorrectos";
                return RedirectToAction("Index");
            }

            // Validar la contraseña (comparación directa - está en texto plano en la BD)
            if (usuario.Contraseña != password)
            {
                // Log para debugging
                Console.WriteLine($"Contraseña incorrecta para usuario: {usuario.Nombre}");
                TempData["Error"] = "Usuario o contraseña incorrectos";
                return RedirectToAction("Index");
            }

            // Guardar en sesión
            HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
            HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
            HttpContext.Session.SetString("Rol", usuario.Rol ?? "Usuario");
            HttpContext.Session.SetString("Correo", usuario.Correo ?? "");

            // IMPORTANTE: Log de login exitoso
            Console.WriteLine($"Login exitoso para usuario: {usuario.Nombre} ({usuario.Correo}) - Rol: {usuario.Rol}");

            // Redirigir al Dashboard
            return RedirectToAction("Index", "Dashboard");
        }
        catch (Exception ex)
        {
            // Log de error
            Console.WriteLine($"Error en login: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            TempData["Error"] = "Ocurrió un error al procesar la solicitud";
            return RedirectToAction("Index");
        }
    }
}

