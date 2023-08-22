using GokalpLogistics.Application.Abstract.Services;
using GokalpLogistics.Application.Concrete.Models.Dto;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks;
using GokalpLogistics.Application.Concrete.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GokalpLogistics.API.Controllers
{
    //Endpoint url => [ControllerRoute]/[ActionRoute]
    //truck/getAllTruck

    [Route("truck")]
    public class TruckController : Controller
    {
        private readonly ITruckService _service;
        public TruckController(ITruckService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<List<TruckDto>>>> GetAllTruck()
        {
            var trucks = await _service.GetAllTruck();
            return Ok(trucks);
        }

        [HttpGet("get/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<TruckDto>>> GetTruckById(int id)
        {
            var category = await _service.GetTruckById(id);
            return Ok(category);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateTruck(TruckRegisterVM truckRegisterVM)
        {
            var categoryId = await _service.CreateTruck(truckRegisterVM);
            return Ok(categoryId);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateTruck(int id, TruckUpdateVM truckUpdateVM)
        {
            if (id != truckUpdateVM.Id)
            {
                return BadRequest();
            }
            var categoryId = await _service.UpdateTruck(truckUpdateVM);
            return Ok(categoryId);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteTruck(int id)
        {
            var categoryId = await _service.DeleteTruck(id);
            return Ok(categoryId);
        }
    }
}
