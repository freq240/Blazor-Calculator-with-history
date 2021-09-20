using BlazorCLC.Interfaces;
using BlazorCLC.Models;
using BlazorCLC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Extensions
{
    public static class ServicesExtentesions
    {
        public static void AddOwnServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculatorState, CalculatorState>();
            services.AddTransient<ICalculatorCIState, CalculatorCIState>();

            services.AddSingleton<ICalculatorCIService, CalculatorCIService>();
            services.AddSingleton<ICalculatorService, CalculatorService>();
            services.AddScoped<IHistoryLoggerService, HistoryLoggerService>();
        }
    }
}
