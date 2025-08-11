using DtaAccess.BsnLogic.Context;
using DtaAccess.BsnLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() => View();
        public IActionResult Privacy() => View();
        public IActionResult Productos() => View();
        public IActionResult Usuarios() => View();
        public IActionResult Grupos() => View();
        public IActionResult Formula() => View();

        [HttpPost]
        public async Task<IActionResult> GuardarFormula(FormulaViewModel model)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var formula = new Formula
                {
                    Nombre = model.NombreFormula,
                    Unidad = model.Unidad
                };

                _context.Formula.Add(formula);
                await _context.SaveChangesAsync();

                foreach (var mat in model.Materiales)
                {
                    var detalle = new FormulaMateriales
                    {
                        IdFormula = formula.IdFormula,
                        IdProducto = mat.IdProducto,
                        Cantidad = mat.Cantidad
                    };
                    _context.FormulaMateriales.Add(detalle);
                }

                await _context.SaveChangesAsync();
                transaction.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                transaction.Rollback();
                return View("Formula", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarProductoConFormula(ProductoFormulaViewModel model)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var producto = new Producto
                {
                    Nombre = model.NombreProducto
                };

                _context.Producto.Add(producto);
                await _context.SaveChangesAsync();

                foreach (var mat in model.Materiales)
                {
                    var detalle = new FormulaMateriales
                    {
                        IdProducto = producto.IdProducto,
                        IdFormula = mat.IdFormula,
                        Cantidad = mat.Cantidad
                    };
                    _context.FormulaMateriales.Add(detalle);
                }

                await _context.SaveChangesAsync();
                transaction.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                transaction.Rollback();
                return View("Productos", model);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
