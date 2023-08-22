using AutoMapper;
using GokalpLogistics.Application.Concrete.Models.Dto;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers;
using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.AutoMapper
{
    public class DriverMapper : Profile
    {
        public DriverMapper()
        {
            CreateMap<Driver,DriverDto>();

            CreateMap<DriverRegisterVM, Driver>();

            CreateMap<DriverUpdateVM, Driver>();
 
        }
    }
}
