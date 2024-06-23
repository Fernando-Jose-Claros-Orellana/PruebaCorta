using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaCorta.LogicaAccesoDatos;
using PruebaCorta.Models;

namespace PruebaCorta.Controllers
{
    [Authorize]
    public class PreguntaController : Controller
    {
        private readonly AccesoDatos _accesoDatos;

        public PreguntaController(AccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }

        //GET : Obtener 
        public async Task<IActionResult> Index()
        {
            var pregunta = await _accesoDatos.ObtenerPregunta();
            return View(pregunta);
        }

        //GET : Crear
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PreguntaM pregunta, string variableVista)
        {
            // Recupera el nombre del usuario autenticado
            string nombreUsuario = User.Identity.Name;

            // Asigna el nombre del usuario al modelo
            pregunta.Nombre = nombreUsuario;
            //Recibe la pregunta de la vista
            pregunta.Pregunta = variableVista;

            pregunta.Estado = 1;
            await _accesoDatos.CrearPregunta(pregunta);
            return RedirectToAction("Index", "Pregunta");

        }

        public async Task<IActionResult> EstadoActivar(PreguntaM pregunta, int id)
        {
            pregunta.Estado = 1;
            await _accesoDatos.Estado(pregunta,id);
            return RedirectToAction("Index", "Pregunta");
        }

        public async Task<IActionResult> EstadoDesactivar(PreguntaM pregunta, int id)
        {
            pregunta.Estado = 0;
            await _accesoDatos.Estado(pregunta, id);
            return RedirectToAction("Index", "Pregunta");
        }

    }
}
