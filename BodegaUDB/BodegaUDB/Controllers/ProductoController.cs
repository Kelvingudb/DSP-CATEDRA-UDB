using BodegaUDB.Dtos;
using BodegaUDB.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BodegaUDB.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly ILoteService _loteService;
        private readonly IProductoService _productoService;
        private readonly ICategoriaProductoService _categoriaProductoService;
        public ProductoController(ILoteService loteService, IProductoService productoService, ICategoriaProductoService categoriaProductoService) {
            _categoriaProductoService = categoriaProductoService;
            _loteService = loteService;
            _productoService = productoService;

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var models = new ProductoFormDto
            {
                Categorias = await _categoriaProductoService.GetAllCategoriasProductos(),
                LoteProductos = await _loteService.GetLotesToProducts()
            };

            return View( models);
        }


        [HttpPost]
        public async Task<IActionResult> RegisterPost(ProductoDto producto)
        {
            bool success = await _productoService.InsertarProductoConDetalle(producto);
           
            var models = new ProductoFormDto
            {
                Categorias = await _categoriaProductoService.GetAllCategoriasProductos(),
                LoteProductos = await _loteService.GetLotesToProducts()
            };


            return View("Register", models);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _productoService.GetProductosInfoAsync();

            return View(productos);
        }
    }
}
