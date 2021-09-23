using BlazorCLC.Extensions;
using BlazorCLC.Interfaces;
using BlazorCLC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorCLC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BlazorCLC.Infrastract;
using MediatR;
using BlazorCLC.Core;

namespace BlazorCLC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddOwnServices();

            services.AddDbContext<HistoryLoggerContext>(options =>
                options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            var assembly = AppDomain.CurrentDomain.Load("BlazorCLC.Core");
            services.AddMediatR(assembly);

            //services.AddMediatR(typeof(MediatoREntryPoint).Assembly);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

        }
    }
}
