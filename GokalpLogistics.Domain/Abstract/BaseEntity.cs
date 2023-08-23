namespace GokalpLogistics.Domain.Abstract
{
    /// <summary>
    /// Bütün nesnelerimizin id ye sahip olması için kurgulanan abstract nesnemiz.
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
