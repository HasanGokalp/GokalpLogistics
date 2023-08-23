using FluentValidation.Results;

namespace GokalpLogistics.Application.Concrete.Exceptions
{
    /// <summary>
    /// Hata özelleştirmeleri.
    /// </summary>
    public class ValidateException : Exception
    {
        public List<string> ErrorMessages { get; set; }

        public ValidateException(ValidationResult result) : base()
        {
            ErrorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
