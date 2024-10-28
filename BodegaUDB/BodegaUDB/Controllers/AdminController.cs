using Microsoft.AspNetCore.Mvc;

namespace BodegaUDB.Controllers
{

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
