using FluentValidation;
using GokalpLogistics.UI.Models.RequestModels.Trucks;

namespace GokalpLogistics.UI.Validators.Trucks
{
    public class TruckRegisterValidation : AbstractValidator<TruckRegisterVM>
    {
        public TruckRegisterValidation()
        {
            RuleFor(x => x.TruckName).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(x => x.TruckModel).NotEmpty().WithMessage("Model boş olamaz");
            RuleFor(x => x.Driver).NotEmpty().WithMessage("Sürücü bilgileri boş olamaz");
            RuleFor(x => x.Lat).NotEmpty().WithMessage("Enlem boş olamaz");
            RuleFor(x => x.Lng).NotEmpty().WithMessage("Boylam boş olamaz");

        }
    }
}
