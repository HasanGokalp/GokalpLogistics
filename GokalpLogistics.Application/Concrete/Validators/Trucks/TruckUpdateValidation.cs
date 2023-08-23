using FluentValidation;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks;

namespace GokalpLogistics.Application.Concrete.Validators.Trucks
{
    public class TruckUpdateValidation : AbstractValidator<TruckUpdateVM>
    {
        public TruckUpdateValidation()
        {
            RuleFor(x => x.TruckName).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(x => x.TruckModel).NotEmpty().WithMessage("Model boş olamaz");
            RuleFor(x => x.Driver).NotEmpty().WithMessage("Sürücü bilgileri boş olamaz");
            RuleFor(x => x.Lat).NotEmpty().WithMessage("Enlem boş olamaz");
            RuleFor(x => x.Lng).NotEmpty().WithMessage("Boylam boş olamaz");

        }
    }
}
