using BodegaUDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BodegaUDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CrearProducto()
        {

            return RedirectToAction("CrearProducto", "ProductoLote");
        }

        public IActionResult CrearLote()
        {
           
            return RedirectToAction("CrearLote", "ProductoLote");
        }

        public IActionResult ListaProductos()
        {
          
            return RedirectToAction("ListaProductos", "ProductoLote");
        }

        public IActionResult ListaLotes()
        {

            return RedirectToAction("ListaLotes", "ProductoLote");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
