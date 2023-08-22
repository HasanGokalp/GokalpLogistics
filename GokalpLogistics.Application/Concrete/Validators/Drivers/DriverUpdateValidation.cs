using FluentValidation;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Drivers;

namespace GokalpLogistics.Application.Concrete.Validators.Drivers
{
    public class DriverUpdateValidation : AbstractValidator<DriverUpdateVM>
    {
        public DriverUpdateValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("İd boş olamaz");
            
        }
    }
}
