using Microsoft.Extensions.DependencyInjection;
using BlazorCLC.Services;
using BlazorCLC.Interfaces;

namespace BlazorCLC.Extensions
{
    public static class CalculatorCIExtension
    {
        public static void AddCalculatorCI(this IServiceCollection services)
        {
            services.AddSingleton<CalculatorCIService>();
        }
    }
}
