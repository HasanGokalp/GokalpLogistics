using ArxOne.MrAdvice.Advice;
using System.Diagnostics;

namespace GokalpLogistics.Application.Concrete.Attributes
{
    /// <summary>
    /// PerformanceAttribute : Attribute, IMethodAdvice =>
    ///     Attribute özelliğini devralması ve mradvice'den de intercept özelliği kazanması için
    ///     sorumluluk yükledik.
    /// ------------------------------------------------------------
    /// => Kullanımı [Performance]
    /// </summary>
    public class PerformanceAttribute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            //Kronometre instance ı oluşturuyoruz
            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();

            //Buradan öncesi çalışmadan öncesi
            context.Proceed();
            //Buradan sonra çalıştıktan sonra olacaklar

            sw.Stop();

            Console.WriteLine(sw.Elapsed.ToString());
        }
    }
}
