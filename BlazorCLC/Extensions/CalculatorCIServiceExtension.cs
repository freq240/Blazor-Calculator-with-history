using Microsoft.Extensions.DependencyInjection;
using BlazorCLC.Services;
using BlazorCLC.Interfaces;

namespace BlazorCLC.Extensions
{
    public static class CalculatorCIServiceExtension
    {
        public static void AddCalculatorCIService(this IServiceCollection services)
        {
            services.AddSingleton<CalculatorCIService>();
        }
    }
}
