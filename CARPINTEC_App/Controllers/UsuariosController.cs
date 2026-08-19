using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CARPINTEC_App.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly CarpintecContext _context;

        public UsuariosController(CarpintecContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }

        // GET: Usuarios/NuevoUsuario
        [HttpGet]
        public IActionResult NuevoUsuario()
        {
            return View();
        }

        // POST: Usuarios/NuevoUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NuevoUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            // Verificar si el correo ya existe
            if (!string.IsNullOrEmpty(usuario.Correo))
            {
                bool correoExiste = await _context.Usuarios
                    .AnyAsync(u => u.Correo == usuario.Correo);

                if (correoExiste)
                {
                    ModelState.AddModelError(
                        "Correo",
                        "Este correo ya está registrado."
                    );

                    return View(usuario);
                }
            }

            // El usuario se crea activo
            usuario.Estado = "Activo";

            // Guardar en la tabla Usuarios
            _context.Usuarios.Add(usuario);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Usuario creado correctamente.";

            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // Cambiar estado del usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Estado = usuario.Estado == "Activo"
                ? "Inactivo"
                : "Activo";

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}