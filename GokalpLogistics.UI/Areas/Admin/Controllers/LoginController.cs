using GokalpLogistics.UI.Extensions;
using GokalpLogistics.UI.Filters.AttributeFilters;
using GokalpLogistics.UI.Models.Dtos;
using GokalpLogistics.UI.Models.RequestModels.Drivers;
using GokalpLogistics.UI.Service.Absract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace GokalpLogistics.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IRestService _restService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public LoginController(IRestService restService, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _restService = restService;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]        
        public async Task<IActionResult> Index(DriverLoginVM loginModel)
        {
            //Model doğrulamasını geçemeyen kullanıcıyı buradan tekrar login sayfasına gönder.
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var response = await _restService.PostAsync<DriverLoginVM, Result<DriverDto>>(loginModel, "driver/DriverLogin");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
            }
            else
            {

                //return RedirectToAction("GetDriverMap", "Home", new { Area = "Admin" }, parametre => çalışan func a parametre yollayabiliriz);
                return RedirectToAction("GetDriverMap", "Home", new { Area = "Admin" });
            }

            return View(loginModel);
        }   

        //[HttpGet]
        //public IActionResult RouteDrive(bool isTrue)
        //{
        //    if (isTrue)
        //    {
        //        ///RestServisten gelebilir
                
        //        return RedirectToAction("GetDriverMap", "Home", new { Area = "Admin"} );
        //    }
        //    return View();
        //}



    }
}
