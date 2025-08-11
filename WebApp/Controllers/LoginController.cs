using DtaAccess.BsnLogic.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;


namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string nombre, string contrasenia)
        {
            //var usuario = await _context.Usuario
                //.Include(u => u.Grupo)
                //.FirstOrDefaultAsync(u => u.Nombre == nombre);

            //if (usuario == null || !VerificarContrasenia(contrasenia, usuario.ContraseniaHash))
            //{
              //  ModelState.AddModelError("", "Usuario o contraseña incorrectos");
              //  return View("Index");
            //}

            var claims = new List<Claim>
        {
            //new Claim(ClaimTypes.Name, usuario.Nombre),
            //new Claim(ClaimTypes.Role, usuario.Grupo.Nombre) 
        };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home"); 
        }

        private bool VerificarContrasenia(string contrasenia, string hash)
        {
            // Acá puedo usar BCrypt, SHA256.
            return contrasenia == hash; 
        }
    }

}
