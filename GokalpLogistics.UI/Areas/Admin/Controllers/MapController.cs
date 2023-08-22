using Microsoft.AspNetCore.Mvc;

namespace GokalpLogistics.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MapController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}
