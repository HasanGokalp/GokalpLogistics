using FluentValidation;
using GokalpLogistics.Application.Concrete.Models.RequestModels.Trucks;

namespace GokalpLogistics.Application.Concrete.Validators.Trucks
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
