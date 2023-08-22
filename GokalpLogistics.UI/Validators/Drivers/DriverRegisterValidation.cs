using FluentValidation;
using GokalpLogistics.Domain.Concrete;
using GokalpLogistics.UI.Models.RequestModels.Drivers;

namespace GokalpLogistics.UI.Validators.Drivers
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
