using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks
{
    /// <summary>
    /// => Bir tır kayıt yapılırken sürücüsü, tır ismi, tır modeli, enlem ve boylamına
    ///     göre işlem yapılır.
    /// </summary>
    public class TruckRegisterVM
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public Driver Driver { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
    }
}
