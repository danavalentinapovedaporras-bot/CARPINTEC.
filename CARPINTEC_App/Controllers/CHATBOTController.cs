using Microsoft.AspNetCore.Mvc;
using CARPINTEC_App.Models;

namespace CARPINTEC_App.Controllers
{
    public class ChatbotController : Controller
    {

        [HttpPost]
        public IActionResult Preguntar([FromBody] MensajeChatbot mensaje)
        {

            string respuesta = "";


            if (mensaje.Mensaje.ToLower().Contains("servicio"))
            {
                respuesta = "CARPINTEC ofrece fabricación de muebles, cocinas integrales, closets y muebles personalizados.";
            }

            else if (mensaje.Mensaje.ToLower().Contains("cotizacion"))
            {
                respuesta = "Puedes solicitar una cotización registrándote e ingresando al módulo de cotizaciones.";
            }

            else if (mensaje.Mensaje.ToLower().Contains("pedido"))
            {
                respuesta = "Puedes consultar el estado de tu pedido desde el módulo de pedidos.";
            }

            else if (mensaje.Mensaje.ToLower().Contains("hola"))
            {
                respuesta = "Hola 👋 soy el asistente virtual de CARPINTEC.";
            }

            else
            {
                respuesta = "No entendí tu pregunta. Puedes consultar sobre servicios, pedidos o cotizaciones.";
            }


            return Json(new
            {
                respuesta = respuesta
            });

        }

    }
}