using FluentValidation;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers;

namespace GokalpLogistics.Application.Concrete.Validators.Drivers
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
