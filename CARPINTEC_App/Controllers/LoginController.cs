using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using CARPINTEC_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CARPINTEC_App.Controllers
{
    public class LoginController : Controller
    {
        private readonly CarpintecContext _context;
        private readonly TokenService _tokenService;

        public LoginController(
            CarpintecContext context,
            TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // =========================
        // Mostrar Login
        // =========================
        public IActionResult Index()
        {
            return View();
        }

        // =========================
        // Cerrar sesión
        // =========================
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();

            Response.Cookies.Delete("tokenJwt");

            return RedirectToAction("Index", "Login");
        }

        // =========================
        // Iniciar sesión
        // =========================
        [HttpPost]
        public async Task<IActionResult> Ingresar(
            string username,
            string password,
            string rol)
        {
            // =========================
            // Validar campos
            // =========================
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(rol))
            {
                TempData["Error"] =
                    "Por favor complete todos los campos.";

                return RedirectToAction("Index");
            }

            try
            {
                // =========================
                // Buscar usuario activo
                // =========================
                var usuario = _context.Usuarios.FirstOrDefault(u =>
                    (
                        (u.Correo != null &&
                         u.Correo.ToLower() == username.ToLower())
                        ||
                        u.Nombre.ToLower() == username.ToLower()
                    )
                    &&
                    u.Estado == "Activo"
                );

                if (usuario == null)
                {
                    TempData["Error"] =
                        "Usuario o contraseña incorrectos.";

                    return RedirectToAction("Index");
                }

                // =========================
                // Verificar contraseña
                // =========================

                var hasher = new PasswordHasher<Usuario>();

                bool acceso = false;

                bool contraseñaYaHasheada =
                    !string.IsNullOrEmpty(usuario.Contraseña) &&
                    usuario.Contraseña.StartsWith("AQAAAA");

                if (contraseñaYaHasheada)
                {
                    // =========================
                    // Usuario que ya tiene hash
                    // =========================

                    var resultado =
                        hasher.VerifyHashedPassword(
                            usuario,
                            usuario.Contraseña,
                            password
                        );

                    acceso =
                        resultado ==
                        PasswordVerificationResult.Success;
                }
                else
                {
                    // =========================
                    // Usuario antiguo
                    // =========================

                    acceso =
                        usuario.Contraseña == password;

                    // =========================
                    // MIGRAR CONTRASEÑA
                    // =========================

                    if (acceso)
                    {
                        usuario.Contraseña =
                            hasher.HashPassword(
                                usuario,
                                password
                            );

                        await _context.SaveChangesAsync();
                    }
                }

                // =========================
                // Contraseña incorrecta
                // =========================

                if (!acceso)
                {
                    TempData["Error"] =
                        "Usuario o contraseña incorrectos.";

                    return RedirectToAction("Index");
                }

                // =========================
                // Convertir rol seleccionado
                // =========================

                string rolSeleccionado =
                    rol.Trim().ToLower();

                string rolEsperado;

                switch (rolSeleccionado)
                {
                    case "cliente":
                        rolEsperado = "Cliente";
                        break;

                    case "admin":
                        rolEsperado = "Administrador";
                        break;

                    case "empleado":
                        rolEsperado = "Empleado";
                        break;

                    default:

                        TempData["Error"] =
                            "Tipo de usuario no válido.";

                        return RedirectToAction("Index");
                }

                // =========================
                // Comprobar rol real
                // =========================

                string rolReal =
                    (usuario.Rol ?? "").Trim();

                if (!rolReal.Equals(
                        rolEsperado,
                        StringComparison.OrdinalIgnoreCase))
                {
                    TempData["Error"] =
                        $"Este usuario no tiene permisos de {rolEsperado}.";

                    return RedirectToAction("Index");
                }

                // =========================
                // Generar JWT
                // =========================

                string token =
                    _tokenService.GenerarToken(usuario);

                // =========================
                // Guardar JWT en cookie
                // =========================

                Response.Cookies.Append(
                    "tokenJwt",
                    token,
                    new CookieOptions
                    {
                        HttpOnly = true,

                        // En desarrollo
                        Secure = false,

                        SameSite =
                            SameSiteMode.Strict,

                        Expires =
                            DateTimeOffset.UtcNow
                                .AddMinutes(60)
                    }
                );

                // =========================
                // Mantener sesión
                // =========================

                HttpContext.Session.SetInt32(
                    "IdUsuario",
                    usuario.IdUsuario
                );

                HttpContext.Session.SetString(
                    "NombreUsuario",
                    usuario.Nombre + " " +
                    usuario.Apellido
                );

                HttpContext.Session.SetString(
                    "Rol",
                    rolReal
                );

                // =========================
                // Redireccionar según
                // el rol REAL de SQL Server
                // =========================

                switch (rolReal.ToLower())
                {
                    case "cliente":

                        return RedirectToAction(
                            "Index",
                            "DashboardCliente"
                        );

                    case "administrador":

                        return RedirectToAction(
                            "Index",
                            "Dashboard"
                        );

                    case "empleado":

                        return RedirectToAction(
                            "Index",
                            "Dashboard"
                        );

                    default:

                        TempData["Error"] =
                            "El rol del usuario no es válido.";

                        Response.Cookies.Delete(
                            "tokenJwt"
                        );

                        return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] =
                    "Error: " + ex.Message;

                return RedirectToAction("Index");
            }
        }
    }
}