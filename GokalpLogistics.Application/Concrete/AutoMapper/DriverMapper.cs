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
            CreateMap<Driver, DriverDto>()
                .ForMember(x => x.DriverName, y => y.MapFrom(y => y.Name))
                .ForMember(x => x.DriverSurname, y => y.MapFrom(y => y.Surname));

            CreateMap<DriverRegisterVM, Driver>()
                .ForMember(x => x.Name, y => y.MapFrom(y => y.DriverName))
                .ForMember(x => x.Surname, y => y.MapFrom(y => y.DriverSurname));

            CreateMap<DriverUpdateVM, Driver>();

            CreateMap<DriverLoginVM, Driver>();



        }
    }
}
