using GokalpLogistics.Application.Concrete.Models.Dto;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks;
using GokalpLogistics.Application.Concrete.Wrapper;

namespace GokalpLogistics.Application.Abstract.Services
{
    public interface ITruckService
    {
        Task<Result<List<TruckDto>>> GetAllTruck();
        Task<Result<TruckDto>> GetTruckById(int id);

        Task<Result<int>> CreateTruck(TruckRegisterVM truckRegisterVM);
        Task<Result<bool>> UpdateTruck(TruckUpdateVM truckUpdateVM);
        Task<Result<bool>> DeleteTruck(int id);
    }
}
