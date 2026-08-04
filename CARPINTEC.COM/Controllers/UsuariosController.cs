using CARPINTEC.COM.Data;
using CARPINTEC.COM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CARPINTEC.COM.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly CarpintecContext _context;

        public UsuariosController(CarpintecContext context)
        {
            _context = context;
        }
        // GET: UsuariosController
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }
        public IActionResult NuevoUsuario()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            usuario.Estado = usuario.Estado == "Activo" ? "Inactivo" : "Activo";

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
      
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

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
