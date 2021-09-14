using Microsoft.Extensions.DependencyInjection;
using BlazorCLC.Services;
using BlazorCLC.Interfaces;

namespace BlazorCLC.Extensions
{
    public static class CalculatorServiceExtension
    {
        public static void AddCalculatorService(this IServiceCollection services)
        {
            services.AddSingleton<CalculatorService>();
        }
    }
}
