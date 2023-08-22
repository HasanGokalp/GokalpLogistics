using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers
{
    /// <summary>
    /// => Bir sürücünün kayıt işlemi yapılırken adı,soyadı, tırına göre yapılır.
    /// </summary>
    public class DriverRegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Truck Truck { get; set; }
    }
}
