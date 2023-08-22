using ArxOne.MrAdvice.Advice;

namespace GokalpLogistics.Application.Concrete.Attributes
{
    /// <summary>
    /// PerformanceAttribute : Attribute, IMethodAdvice =>
    ///     Attribute özelliğini devralması ve mradvice'den de intercept özelliği kazanması için
    ///     sorumluluk yükledik.
    /// -----------------------------------------------------------
    /// => Kullanımı [Validate(typeof())]
    /// </summary>
    public class ValidateAttribute : Attribute, IMethodAdvice
    {
        private readonly Type _validatorType; // => DriverRegisterVM

        public ValidateAttribute(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public void Advise(MethodAdviceContext context)
        {
            //Metod çalışmadan önce devreye girecek kodlar.

            if (context.Arguments.Any())
            {
                var requestModel = context.Arguments[0]; // => DriverRegisterVM

                //Request model doğrulaması - Fluent Validation
                var validateMethod = _validatorType.GetMethod("Validate", new Type[] { requestModel.GetType() });
                var validatorInstance = Activator.CreateInstance(_validatorType); // new CreateCategoryValidator()
                if (validateMethod != null)
                {
                    var validationResult = validateMethod.Invoke(validatorInstance, new object[] { requestModel });
                    if (validationResult == null)
                    {
                        throw new Exception("Hata");
                    }
                }
            }

            context.Proceed();


            //Metod çalıştıktan sonra devreye girecek kodlar.
        }
    }
}
