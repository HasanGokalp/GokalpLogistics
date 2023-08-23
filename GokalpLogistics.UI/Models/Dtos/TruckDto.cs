using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.UI.Models.Dtos
{
    public class TruckDto
    {
        public string TruckName { get; set; }
        public string TruckModel { get; set; }
        public Driver Driver { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
    }
}
