using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
 using Newtonsoft.Json.Serialization;
using SyncfusionBlazorAppMaterialTheme.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionBlazorAppMaterialTheme
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSyncfusionBlazor();
            services.AddSingleton<PowerPointService>();
            services.AddSingleton<WordService>();
            services.AddSingleton<PdfService>();
            services.AddSingleton<ExcelService>();
            services.AddRazorPages();
            services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });
            services.AddSignalR(e => { e.MaximumReceiveMessageSize = 102400000; });
            services.AddSignalR(e => { e.MaximumReceiveMessageSize = 102400000; });
            services.AddServerSideBlazor().AddHubOptions(o=>
            {
                o.MaximumReceiveMessageSize=102400000;
            });
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Add your Syncfusion license key for Blazor platform with corresponding Syncfusion NuGet version referred in project. For more information about license key see https://help.syncfusion.com/common/essential-studio/licensing/license-key.
            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Add your license key here");
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDgzNUAzMTM4MmUzNDJlMzBFNTFZdHBJQkROTWFMWDQ1dlBoWlNMWERoditkeXlFQVIxcCtuYnc4VTJNPQ==");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
