using FluentValidation;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks;

namespace GokalpLogistics.Application.Concrete.Validators.Trucks
{
    public class TruckUpdateValidation : AbstractValidator<TruckUpdateVM>
    {
        public TruckUpdateValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("İd boş olamaz");

        }
    }
}
