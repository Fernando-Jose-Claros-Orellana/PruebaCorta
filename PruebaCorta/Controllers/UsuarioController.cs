using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaCorta.LogicaAccesoDatos;
using PruebaCorta.Models;
using System.Security.Claims;

namespace PruebaCorta.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AccesoDatos _accesoDatos;

        public UsuarioController(AccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }

        //-----------------------------CrearUsuario----------------------------

        //GET : Crear
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crear
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            bool creacionExitosa = await _accesoDatos.Crear(usuario);

            if (creacionExitosa)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario o correo en existencia");
                return View(usuario);
            }


        }

        //----------------------------------------------------------------------------

        //------------------------LoginUsuario----------------------------------------

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login", "Usuario");
        }

        // GET: Login
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        // POST: Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuario usuario)
        {

            bool loginCorrecto = await _accesoDatos.Login(usuario);

            if (loginCorrecto)
            {
               
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

                return RedirectToAction("Index", "Pregunta");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos");
                return View(usuario);
            }

        }

        //----------------------------------------------------------------------------

    }
}
