using FluentValidation;
using GokalpLogistics.UI.Models.RequestModels.Drivers;

namespace GokalpLogistics.UI.Validators.Drivers
{
    public class DriverUpdateValidation : AbstractValidator<DriverUpdateVM>
    {
        public DriverUpdateValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("İd boş olamaz");

        }
    }
}
