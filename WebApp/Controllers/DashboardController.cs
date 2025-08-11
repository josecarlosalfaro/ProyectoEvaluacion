using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult VistaAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Producción")]
        public IActionResult VistaUsuario()
        {
            return View();
        }
    }
}
