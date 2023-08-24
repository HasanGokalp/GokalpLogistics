using Microsoft.AspNetCore.Mvc;

namespace GokalpLogistics.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        const string _driverName = "DriverName";

        [HttpGet]
        public IActionResult Index(string? str)
        {
            //if (str == null)
            //{
            //    ViewBag.User = "Kullanıcı girili değil";
            //    ViewBag.Login = "Giriş yapmak için tıklayınız";
            //}
            //else
            //{
            //    ViewBag.User = str;
            //    ViewBag.Login = "Profil";
            //}

            if (HttpContext.Session.GetString("DriverName") == "hasan")
            {
                ViewBag.User = HttpContext.Session.GetString("DriverName");
            }

            return View();
        }


        [HttpGet]
        public ActionResult GetDriverMap()
        {
            ViewBag.lat = 41; 
            ViewBag.lng = 26;
            
            return View();
        }
    }
}
