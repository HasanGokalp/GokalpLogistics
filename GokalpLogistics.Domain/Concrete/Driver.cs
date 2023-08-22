using GokalpLogistics.Domain.Abstract;

namespace GokalpLogistics.Domain.Concrete
{
    /// <summary>
    /// Driver : BaseEntity => Bütün sürücülerimizin id ye sahip olmasını istiyoruz.
    /// --------------------------------------------------
    /// Bütün sürücülerimizi ismine,soyadı ve tırlarına göre tanımladık.
    /// --------------------------------------------------
    /// Truck Truck => Navigation Property. Bire bir ilişki.Bütün sürücülerin bir tane tırı sürebileceğini
    /// ima ediyoruz.
    /// </summary>
    public class Driver : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Truck Truck { get; set; }
    }
}
