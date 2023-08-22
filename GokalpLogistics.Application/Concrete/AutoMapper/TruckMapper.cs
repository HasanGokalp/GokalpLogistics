using AutoMapper;
using GokalpLogistics.Application.Concrete.Models.Dto;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks;
using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.AutoMapper
{
    public class TruckMapper : Profile
    {
        public TruckMapper()
        {
            CreateMap<Truck, TruckDto>();

            CreateMap<TruckRegisterVM, Truck>();

            CreateMap<TruckUpdateVM, Truck>();

        }
    }
}
