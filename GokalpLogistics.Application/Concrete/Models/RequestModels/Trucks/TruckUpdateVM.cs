using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks
{
    /// <summary>
    /// => Bir tır güncellenirken sürücüsü(olmayabilir), enlem ve boylam
    ///     bilgilerine göre güncellenir.
    /// </summary>
    public class TruckUpdateVM
    {
        public string TruckName { get; set; }
        public string TruckModel { get; set; }
        public Driver Driver { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
    }
}
