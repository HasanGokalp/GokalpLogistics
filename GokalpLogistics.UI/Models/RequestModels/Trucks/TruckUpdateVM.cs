using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.UI.Models.RequestModels.Trucks
{
    public class TruckUpdateVM
    {
        public string TruckName { get; set; }
        public string TruckModel { get; set; }
        public Driver Driver { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
    }
}
