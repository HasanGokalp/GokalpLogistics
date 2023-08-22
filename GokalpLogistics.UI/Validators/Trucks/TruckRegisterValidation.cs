using FluentValidation;
using GokalpLogistics.UI.Models.RequestModels.Trucks;

namespace GokalpLogistics.UI.Validators.Trucks
{
    public class TruckRegisterValidation : AbstractValidator<TruckRegisterVM>
    {
        public TruckRegisterValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model boş olamaz");

        }
    }
}
