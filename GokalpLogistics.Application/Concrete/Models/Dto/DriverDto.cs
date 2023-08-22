using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.Models.Dto
{
    public class DriverDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Truck? Truck { get; set; }
    }
}
