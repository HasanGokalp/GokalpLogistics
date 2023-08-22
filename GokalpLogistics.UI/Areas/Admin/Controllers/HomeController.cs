using Microsoft.AspNetCore.Mvc;

namespace GokalpLogistics.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.User = "Kullanıcı girili değil";
            ViewBag.Login = "Giriş yapmak için tıklayınız";
            return View();
        }
    }
}
