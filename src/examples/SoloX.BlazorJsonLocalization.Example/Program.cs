using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SoloX.BlazorJsonLocalization;

namespace SoloX.BlazorJsonLocalization.Example
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddJsonLocalization(
                builder => builder.UseEmbeddedJson(options =>
                {
                    options.ResourcesPath = "Resources";
                    options.AssemblyNames = new[] { typeof(Program).Assembly.GetName().Name };
                }));

            await builder.Build().RunAsync();
        }
    }
}
