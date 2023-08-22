using FluentValidation;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers;
using GokalpLogistics.Domain.Concrete;

namespace GokalpLogistics.Application.Concrete.Validators.Drivers
{
    public class DriverRegisterValidation : AbstractValidator<DriverRegisterVM>
    {
        public DriverRegisterValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş olamaz");
        }
    }
}
