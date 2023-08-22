using AutoMapper;
using GokalpLogistics.Domain.Concrete;
using GokalpLogistics.UI.Models.Dtos;
using GokalpLogistics.UI.Models.RequestModels.Trucks;

namespace GokalpLogistics.UI.AutoMapper
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
