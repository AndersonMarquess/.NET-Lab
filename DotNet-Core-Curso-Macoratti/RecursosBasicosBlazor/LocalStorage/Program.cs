using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Blazor.Hosting;

namespace LocalStorage
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            RegistrarServicos(builder);

            await builder.Build().RunAsync();
        }

        private static void RegistrarServicos(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddBlazoredLocalStorage();
        }
    }
}
