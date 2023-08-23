using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers
{
    /// <summary>
    /// => Bir sürücünün kayıt işlemi yapılırken adı,soyadı, tırına göre yapılır.
    /// </summary>
    public class DriverRegisterVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int TruckId { get; set; }
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
        public Truck Truck { get; set; }
    }
}
