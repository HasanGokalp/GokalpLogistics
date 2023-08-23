using FluentValidation;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers;

namespace GokalpLogistics.Application.Concrete.Validators.Drivers
{
    public class DriverRegisterValidation : AbstractValidator<DriverRegisterVM>
    {
        public DriverRegisterValidation()
        {
            RuleFor(x => x.DriverName).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(x => x.DriverSurname).NotEmpty().WithMessage("Soyisim boş olamaz");
            RuleFor(x => x.TruckId).NotEmpty().WithMessage("Tırın idsi boş olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Truck).NotEmpty().WithMessage("Tır bilgileri boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre boş olamaz");
        }
    }
}
