using GokalpLogistics.Domain.Abstract;

namespace GokalpLogistics.Domain.Concrete
{
    /// <summary>
    /// Truck : BaseEntity => bütün tırlarımızın id ye sahip olmasını istiyoruz.
    /// --------------------------------------------------
    /// Bütün tırlamızı şöförlerine, markasına, modellerine göre tanımladık.
    /// --------------------------------------------------
    /// Driver Driver => Navigation Property. Bire bir ilişki.Her bir tırımızın sadece bir tane 
    /// sürücüsünün olmasını istediğimiz için.
    /// --------------------------------------------------
    /// int Lat ^ Lng => Enlem ve boylam. Her tırın mevcut olduğu koordinatları.
    /// </summary>
    public class Truck : BaseEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public Driver Driver { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
    }
}
