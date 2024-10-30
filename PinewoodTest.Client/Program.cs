using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace PinewoodTest.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // this HttpClient base address ideally wouldn't be hardcoded, but just to make this task a tad simpler...
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5245/api/") });

            await builder.Build().RunAsync();
        }
    }
}
