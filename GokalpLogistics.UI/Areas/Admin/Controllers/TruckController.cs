using Microsoft.AspNetCore.Mvc;

namespace GokalpLogistics.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TruckController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
