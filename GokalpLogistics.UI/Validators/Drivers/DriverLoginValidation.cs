using FluentValidation;
using GokalpLogistics.UI.Models.RequestModels.Drivers;

namespace GokalpLogistics.UI.Validators.Drivers
{
    public class DriverLoginValidator : AbstractValidator<DriverLoginVM>
    {
        public DriverLoginValidator()
        {

            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre boş olamaz");
        }
    }
}
