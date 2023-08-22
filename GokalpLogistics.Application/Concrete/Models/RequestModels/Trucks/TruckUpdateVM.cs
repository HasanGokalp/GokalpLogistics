namespace GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks
{
    /// <summary>
    /// => Bir tır güncellenirken sürücüsü(olmayabilir), enlem ve boylam
    ///     bilgilerine göre güncellenir.
    /// </summary>
    public class TruckUpdateVM
    {
        public int Id { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
    }
}
