using AutoMapper;
using GokalpLogistics.Domain.Concrete;
using GokalpLogistics.UI.Models.Dtos;
using GokalpLogistics.UI.Models.RequestModels.Drivers;

namespace GokalpLogistics.UI.AutoMapper
{
    public class DriverMapper : Profile
    {
        public DriverMapper()
        {
            CreateMap<Driver, DriverDto>();

            CreateMap<DriverRegisterVM, Driver>();

            CreateMap<DriverUpdateVM, Driver>();
        }
    }
}
