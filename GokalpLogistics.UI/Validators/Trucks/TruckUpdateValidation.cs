using FluentValidation;
using GokalpLogistics.UI.Models.RequestModels.Trucks;

namespace GokalpLogistics.UI.Validators.Trucks
{
    public class TruckUpdateValidation : AbstractValidator<TruckUpdateVM>
    {
        public TruckUpdateValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("İd boş olamaz");

        }
    }
}
