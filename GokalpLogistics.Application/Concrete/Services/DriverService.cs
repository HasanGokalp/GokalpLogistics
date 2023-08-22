using AutoMapper;
using AutoMapper.QueryableExtensions;
using GokalpLogistics.Application.Abstract.Services;
using GokalpLogistics.Application.Concrete.Models.Dto;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers;
using GokalpLogistics.Application.Concrete.Wrapper;
using GokalpLogistics.Domain.Concrete;
using GokalpLogistics.Persistence.Abstract.UnitWork;
using System.Security.Principal;

namespace GokalpLogistics.Application.Concrete.Services
{
    /// <summary>
    /// DriverService : IDriverService => Service interfaceinden sorumluluk alınıyor implementasyon için.
    /// </summary>

    public class DriverService : IDriverService
    {
        private readonly IUnitWork Db;
        private readonly IMapper Mapper;

        public DriverService(IUnitWork db, IMapper mapper)
        {
            Db = db;
            Mapper = mapper;
        }

        public async Task<Result<int>> CreateDriver(DriverRegisterVM driverRegisterVM)
        {
            var result = new Result<int>();

            var driverNameExists = await Db.GetRepository<Driver>().AnyAsync(x => x.Name == driverRegisterVM.Name.ToUpper().Trim());
            if (driverNameExists)
            {
                throw new Exception($"{driverRegisterVM.Name} isminde bir sürücü eklenmiştir.");
            }

            var driverEntity = Mapper.Map<Driver>(driverRegisterVM);

            Db.GetRepository<Driver>().Add(driverEntity);
            await Db.CommitAsync();

            result.Data = driverEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteDriver(int id)
        {
            var result = new Result<bool>();

            var driverById = await Db.GetRepository<Driver>().GetById(id);
            if (driverById is null)
            {
                throw new Exception($"{id} numaralı sürücü bulunamadı.");
            }

            Db.GetRepository<Driver>().Delete(driverById);

            result.Data = await Db.CommitAsync();

            return result;
        }

        public async Task<Result<List<DriverDto>>> GetAllDriver()
        {
            var result = new Result<List<DriverDto>>();

            var driverEntites = await Db.GetRepository<Driver>().GetAllAsync();
            var driverDtos = driverEntites.ProjectTo<DriverDto>(Mapper.ConfigurationProvider).ToList();

            result.Data = driverDtos;
            return result;
        }

        public async Task<Result<DriverDto>> GetDriverById(int id)
        {
            var result = new Result<DriverDto>();

            var driverEntity = await Db.GetRepository<Driver>().GetById(id);

            var driverDto = Mapper.Map<DriverDto>(driverEntity);

            result.Data = driverDto;
            return result;
        }

        public async Task<Result<bool>> LoginDriver(DriverRegisterVM driverRegisterVM)
        {
            var list = new Result<bool>();
            var existsAccount = await Db.GetRepository<Driver>().GetSingleByFilterAsync(x => x.Name == driverRegisterVM.Name);
            //Kullanıcı yoksa hata fırlat.
            if (existsAccount is null)
            {
                throw new Exception($"{driverRegisterVM.Name} kullanıcı adına sahip kullanıcı bulunamadı ye da parola hatalıdır.");
            }
            list.Data = true;
            return list;
        }

        public async Task<Result<bool>> UpdateDriver(DriverUpdateVM driverUpdateVM)
        {
            var result = new Result<bool>();

            var driverIdExists = await Db.GetRepository<Driver>().AnyAsync(x => x.Id == driverUpdateVM.Id);
            if (!driverIdExists)
            {
                throw new Exception($"{driverUpdateVM.Id} numaralı şehir bulunamadı.");
            }

            var existsDriverEntity = await Db.GetRepository<Driver>().GetById(driverUpdateVM.Id);

            Mapper.Map(driverUpdateVM, existsDriverEntity);

            Db.GetRepository<Driver>().Update(existsDriverEntity);
            result.Data = await Db.CommitAsync();

            return result;
        }
    }
}
