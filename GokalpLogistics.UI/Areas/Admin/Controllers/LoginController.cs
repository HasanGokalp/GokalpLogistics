using GokalpLogistics.UI.Models.RequestModels.Drivers;
using GokalpLogistics.UI.Service.Absract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DriverLoginVM driverModel, [FromQuery] string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(driverModel);
            }
            
            var response = await _restService.PostAsync<DriverLoginVM, Result<bool>>(driverModel, "driver/LoginDriver");
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
            }
            else
            {
            
                var deneme = JsonConvert.SerializeObject(response.Data.Data);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                    //return RedirectToAction("Index", "Map"/*, new { Area = "Admin" }*/);
                }
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            return View(driverModel);
        }
    }
}
