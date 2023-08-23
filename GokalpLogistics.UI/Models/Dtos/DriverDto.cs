using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.UI.Models.Dtos
{
    public class DriverDto
    {
        public int TruckId { get; set; }
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
        public Truck Truck { get; set; }
    }
}
