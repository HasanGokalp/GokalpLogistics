using AutoMapper;
using AutoMapper.QueryableExtensions;
using GokalpLogistics.Application.Abstract.Services;
using GokalpLogistics.Application.Concrete.Attributes;
using GokalpLogistics.Application.Concrete.Models.Dto;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks;
using GokalpLogistics.Application.Concrete.Validators.Trucks;
using GokalpLogistics.Application.Concrete.Wrapper;
using GokalpLogistics.Domain.Concrete;
using GokalpLogistics.Persistence.Abstract.UnitWork;

namespace GokalpLogistics.Application.Concrete.Services
{
    public class TruckService : ITruckService
    {
        private readonly IUnitWork Db;
        private readonly IMapper Mapper;

        public TruckService(IUnitWork db, IMapper mapper)
        {
            Db = db;
            Mapper = mapper;
        }
        [Performance]
        [Validate(typeof(TruckRegisterValidation))]
        public async Task<Result<int>> CreateTruck(TruckRegisterVM TruckRegisterVM)
        {
            var result = new Result<int>();

            var TruckNameExists = await Db.GetRepository<Truck>().AnyAsync(x => x.Name == TruckRegisterVM.Name.ToUpper().Trim());
            if (TruckNameExists)
            {
                throw new Exception($"{TruckRegisterVM.Name} isminde bir sürücü eklenmiştir.");
            }

            var TruckEntity = Mapper.Map<Truck>(TruckRegisterVM);

            Db.GetRepository<Truck>().Add(TruckEntity);
            await Db.CommitAsync();

            result.Data = TruckEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteTruck(int id)
        {
            var result = new Result<bool>();

            var TruckById = await Db.GetRepository<Truck>().GetById(id);
            if (TruckById is null)
            {
                throw new Exception($"{id} numaralı sürücü bulunamadı.");
            }

            Db.GetRepository<Truck>().Delete(TruckById);

            result.Data = await Db.CommitAsync();

            return result;
        }

        public async Task<Result<List<TruckDto>>> GetAllTruck()
        {
            var result = new Result<List<TruckDto>>();

            var TruckEntites = await Db.GetRepository<Truck>().GetAllAsync();
            var TruckDtos = TruckEntites.ProjectTo<TruckDto>(Mapper.ConfigurationProvider).ToList();

            result.Data = TruckDtos;
            return result;
        }

        public async Task<Result<TruckDto>> GetTruckById(int id)
        {
            var result = new Result<TruckDto>();

            var TruckEntity = await Db.GetRepository<Truck>().GetById(id);

            var TruckDto = Mapper.Map<TruckDto>(TruckEntity);

            result.Data = TruckDto;
            return result;
        }

        [Performance]
        [Validate(typeof(TruckUpdateValidation))]
        public async Task<Result<bool>> UpdateTruck(TruckUpdateVM TruckUpdateVM)
        {
            var result = new Result<bool>();

            var TruckIdExists = await Db.GetRepository<Truck>().AnyAsync(x => x.Id == TruckUpdateVM.Id);
            if (!TruckIdExists)
            {
                throw new Exception($"{TruckUpdateVM.Id} numaralı şehir bulunamadı.");
            }

            var existsTruckEntity = await Db.GetRepository<Truck>().GetById(TruckUpdateVM.Id);

            Mapper.Map(TruckUpdateVM, existsTruckEntity);

            Db.GetRepository<Truck>().Update(existsTruckEntity);
            result.Data = await Db.CommitAsync();

            return result;
        }
    }
}
