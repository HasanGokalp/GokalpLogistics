using GokalpLogistics.UI.Models.Dtos;

namespace GokalpLogistics.UI.Extensions
{
    public class SesionManager
    {

        public static DriverDto? LoggedUser
        {
            get => AppHttpContext.Current.Session.GetObject<DriverDto>("DriverDto");
            set => AppHttpContext.Current.Session.SetObject("DriverDtos", value);
        }
    }
}
