using Microsoft.Extensions.DependencyInjection;
using BlazorCLC.Services;
namespace BlazorCLC.Extensions
{
    public static class CalculatorExtension
    {
        public static void AddCalculator(this IServiceCollection services)
        {
            services.AddSingleton<CalculatorService>();
        }
    }
}
