using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaCorta.LogicaAccesoDatos;
using PruebaCorta.Models;

namespace PruebaCorta.Controllers
{
    [Authorize]
    public class RespuestaController : Controller
    {
        private readonly AccesoDatos _accesoDatos;

        public RespuestaController(AccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }

        public async Task<IActionResult> Index(int id)
        {

            var respuesta = await _accesoDatos.ObtenerRespuesta(id);
            if (respuesta == null)
            {
                return RedirectToAction("Index", "Respuesta");
            }
            return View(respuesta);
        }

        //GET : Crear
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RespuestaM respuesta,int id, string variableVista)
        {
            string nombreUsuario = User.Identity.Name;

            
            respuesta.Nombre = nombreUsuario;
           
            respuesta.Respuesta = variableVista;
            
            if (id > 0)
            {
                respuesta.IdPregunta = id;
            }

            await _accesoDatos.CrearRespuesta(respuesta);
            return RedirectToAction("Index", "Pregunta");

        }
    }
}
