namespace GokalpLogistics.Application.Concrete.Exceptions
{
    /// <summary>
    /// Hata özelleştirmeleri.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException() : base()
        {

        }
    }
    
}
