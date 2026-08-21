using CARPINTEC_App.Data;
using CARPINTEC_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CARPINTEC_App.Controllers
{
    [Authorize]
    public class EmpleadosController : Controller
    {

        private readonly CarpintecContext _context;


        public EmpleadosController(CarpintecContext context)
        {
            _context = context;
        }



        // LISTAR EMPLEADOS

        public async Task<IActionResult> Index()
        {

            var empleados = await _context.Empleados
                .ToListAsync();


            return View(empleados);

        }




        // CREAR EMPLEADO

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NuevoEmpleado(Empleado empleado)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }



            // Estado inicial

            empleado.Estado = "Activo";



            _context.Empleados.Add(empleado);



            await _context.SaveChangesAsync();



            TempData["Success"] = "Empleado creado correctamente";



            return RedirectToAction(nameof(Index));

        }




        // OBTENER DATOS PARA MODAL VER

        [HttpGet]
        public async Task<IActionResult> ObtenerEmpleado(int id)
        {

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(e => e.IdEmpleado == id);



            if (empleado == null)
            {
                return NotFound();
            }


            return Json(empleado);

        }





        // EDITAR EMPLEADO

        [HttpPost]
        public async Task<IActionResult> EditarEmpleado([FromBody] Empleado empleado)
        {


            var empleadoBD = await _context.Empleados
                .FirstOrDefaultAsync(e => e.IdEmpleado == empleado.IdEmpleado);



            if (empleadoBD == null)
            {
                return NotFound();
            }



            empleadoBD.Documento = empleado.Documento;

            empleadoBD.Nombre = empleado.Nombre;

            empleadoBD.Apellido = empleado.Apellido;

            empleadoBD.Cargo = empleado.Cargo;

            empleadoBD.Correo = empleado.Correo;

            empleadoBD.Telefono = empleado.Telefono;

            empleadoBD.Direccion = empleado.Direccion;

            empleadoBD.Salario = empleado.Salario;



            _context.Update(empleadoBD);



            await _context.SaveChangesAsync();



            return Ok();

        }





        // CAMBIAR ESTADO

        [HttpPost]
        public async Task<IActionResult> CambiarEstado([FromBody] EstadoEmpleado datos)
        {


            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(e => e.IdEmpleado == datos.IdEmpleado);



            if (empleado == null)
            {
                return NotFound();
            }



            empleado.Estado = datos.Estado;



            await _context.SaveChangesAsync();



            return Ok();

        }


    }
}