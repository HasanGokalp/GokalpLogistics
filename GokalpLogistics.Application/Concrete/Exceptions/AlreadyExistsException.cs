namespace GokalpLogistics.Application.Concrete.Exceptions
{
    /// <summary>
    /// Hata özelleştirmeleri.
    /// </summary>
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message)
        {

        }

        public AlreadyExistsException() : base()
        {

        }
    }
}
