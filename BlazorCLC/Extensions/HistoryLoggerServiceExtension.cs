using BlazorCLC.Interfaces;
using BlazorCLC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Extensions
{
    public static class HistoryLoggerServiceExtension
    {
        public static void AddHistoryLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<IHistoryLoggerService, HistoryLoggerService>();
        }
    }
}
