using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.UI.Models.Dtos
{
    public class DriverDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Truck? Truck { get; set; }
    }
}
