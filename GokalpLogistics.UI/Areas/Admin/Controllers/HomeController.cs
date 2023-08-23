using Microsoft.AspNetCore.Mvc;

namespace GokalpLogistics.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index(string? str)
        {
            if (str == null)
            {
                ViewBag.User = "Kullanıcı girili değil";
                ViewBag.Login = "Giriş yapmak için tıklayınız";
            }
            else
            {
                ViewBag.User = str;
                ViewBag.Login = "Profil";
            }
            return View();
        }
    }
}
