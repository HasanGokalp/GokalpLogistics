using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.UI.Models.RequestModels.Drivers
{
    public class DriverRegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Truck Truck { get; set; }
    }
}
