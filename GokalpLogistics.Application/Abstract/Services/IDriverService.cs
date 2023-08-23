using GokalpLogistics.Application.Concrete.Models.Dto;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers;
using GokalpLogistics.Application.Concrete.Wrapper;

namespace GokalpLogistics.Application.Abstract.Services
{
    public interface IDriverService
    {
        Task<Result<List<DriverDto>>> GetAllDriver();
        Task<Result<DriverDto>> GetDriverById(int id);

        Task<Result<int>> CreateDriver(DriverRegisterVM driverRegisterVM);
        Task<Result<bool>> UpdateDriver(DriverUpdateVM driverUpdateVM);
        Task<Result<bool>> DeleteDriver(int id);
        Task<Result<bool>> LoginDriver(DriverLoginVM driverLoginVM);
    }
}
