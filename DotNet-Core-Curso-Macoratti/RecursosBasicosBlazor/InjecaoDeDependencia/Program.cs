using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using InjecaoDeDependencia.Servicos;

namespace InjecaoDeDependencia
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            ConfigurarServicos(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigurarServicos(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<ServicoSingleton>();
            builder.Services.AddScoped<ServicoScoped>();
            builder.Services.AddTransient<ServicoTransient>();
        }
    }
}
