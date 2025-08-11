using DtaAccess.BsnLogic;
using DtaAccess.BsnLogic.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AppDbContext _context;

        public CuentaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> LoginSimple(LoginViewModel model)
        {
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Nombre == model.Nombre && u.ContraseniaHash == model.Contrasenia);
            var producto = await _context.Producto.FirstOrDefaultAsync();

            if (usuario == null)
                return View("Login");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> LoginAvanzado(LoginViewModel model)
        {
            var usuario = await _context.Usuario
                .Include(u => u.Grupo)
                .FirstOrDefaultAsync(u => u.Nombre == model.Nombre && u.ContraseniaHash == model.Contrasenia);

            if (usuario == null)
                return View("Login");

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Nombre),
            new Claim(ClaimTypes.Role, usuario.Grupo.Nombre)
        };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // Redirige según grupo
            if (usuario.Grupo.Nombre == "Admin")
                return RedirectToAction("VistaAdmin", "Dashboard");
            else if (usuario.Grupo.Nombre == "Producción")
                return RedirectToAction("VistaUsuario", "Dashboard");
            else
                return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccesoDenegado() => View();
    }
}
