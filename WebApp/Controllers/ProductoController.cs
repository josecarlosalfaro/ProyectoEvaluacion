using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Policy = "GrupoProduccion")]
public class ProductoController : Controller
{
    public IActionResult Produccion()
    {
        return View();
    }
}

