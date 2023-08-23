namespace GokalpLogistics.Domain.Concrete
{
    /// <summary>
    /// Additional source : 
    ///     https://developers.google.com/maps/documentation/maps-static/start?hl=tr#Locations
    /// --------------------------------------------------
    /// Map => Oluşturulacak ve gösterilecek haritanın alınan apideki parametreleri
    ///     (Harita yakınlaşması, haritanın ekrandaki büyüklüğü, gösterilecek yer).
    ///  Örn => 
    ///     https://maps.googleapis.com/maps/api/staticmap?center=40.714728,-73.998672&zoom=12&size=400x400&key=YOUR_API_KEY&signature=YOUR_SIGNATURE
    /// --------------------------------------------------
    /// Amaç daha dinamik yönetilen bir harita.
    /// </summary>
    public class Map
    {
        public int Zoom { get; set; }
        public int Size { get; set; }
       
        

    }
}
