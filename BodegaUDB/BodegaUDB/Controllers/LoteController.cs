using BodegaUDB.Dtos;
using BodegaUDB.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BodegaUDB.Controllers
{
    [Authorize]
    public class LoteController : Controller
    {
        private readonly IProveedorService _proveedorService;
        private readonly ILoteService _loteService;
        public LoteController(IProveedorService proveedorService, ILoteService loteService) {
            _proveedorService = proveedorService;
            _loteService = loteService;

        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Register()
        {

            var proveedoresLote = await _proveedorService.GetAllProveedoresLote();
            return View(proveedoresLote);
        }



        [HttpPost]
        public async Task<IActionResult> RegisterPost(LoteRegisterDto loteDto)
        {
            var message = await _loteService.InsertLote(loteDto);

            return View(message);
        }

        [HttpGet]
        public async Task<IActionResult> Lotes()
        {
            var lotes = await _loteService.GetAllLotes();
            var proveedores = await _proveedorService.GetAllProveedoresLote();

            var viewModel = new LotesProveedoresDto()
            {
                Lotes = lotes,
                Proveedores = proveedores
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarLote(LoteUpdateDto loteUpdate)
        {
            await _loteService.UpdateLote(loteUpdate);
            return RedirectToAction("Lotes");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarLote([FromBody] LoteDeleteDto loteDeleteDto)
        {
            await _loteService.DeleteLote(loteDeleteDto);
            return RedirectToAction("Lotes");
        }
    }
}
