using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.Models.Dto
{
    public class TruckDto
    {
        public string TruckName { get; set; }
        public string TruckModel { get; set; }
        public DriverDto Driver { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
    }
}
