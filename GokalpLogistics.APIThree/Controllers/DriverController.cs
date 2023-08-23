using GokalpLogistics.Application.Abstract.Services;
using GokalpLogistics.Application.Concrete.Models.Dto;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers;
using GokalpLogistics.Application.Concrete.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GokalpLogistics.API.Controllers
{
    //Endpoint url => [ControllerRoute]/[ActionRoute]
    //driver/getAllDriver

    [Route("driver")]
    public class DriverController : Controller
    {
        private readonly IDriverService _service;
        public DriverController(IDriverService service)
        {
            _service = service;
        }

        [HttpGet("LoginDriver")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<List<bool>>>> LoginDriver(DriverRegisterVM driverRegisterVM)
        {
            var drivers = await _service.LoginDriver(driverRegisterVM);
            return Ok(drivers);
        }

        [HttpGet("get")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<List<DriverDto>>>> GetAllDriver()
        {
            var drivers = await _service.GetAllDriver();
            return Ok(drivers);
        }

        [HttpGet("get/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<DriverDto>>> GetDriverById(int id)
        {
            var category = await _service.GetDriverById(id);
            return Ok(category);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateDriver(DriverRegisterVM DriverRegisterVM)
        {
            var categoryId = await _service.CreateDriver(DriverRegisterVM);
            return Ok(categoryId);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateDriver(int id, DriverUpdateVM DriverUpdateVM)
        {
            if (id != DriverUpdateVM.Id)
            {
                return BadRequest();
            }
            var categoryId = await _service.UpdateDriver(DriverUpdateVM);
            return Ok(categoryId);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteDriver(int id)
        {
            var categoryId = await _service.DeleteDriver(id);
            return Ok(categoryId);
        }
    }
}
