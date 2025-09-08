using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Testhardo;

internal static class Program
{
    public static JsonSerializerOptions DefaultJsonSerializerOptions { get; set; } = new JsonSerializerOptions { WriteIndented = true, AllowTrailingCommas = true };
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        var host = GetHost();

        ServiceProvider = host.Services;

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.SetCompatibleTextRenderingDefault(false);
        ApplicationConfiguration.Initialize();
        Application.Run(ServiceProvider.GetRequiredService<MainForm>());
    }

    static IHost GetHost()
    {
        var builder = Host.CreateApplicationBuilder();

        //builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        builder.Services.AddTransient<MainForm>();
        //builder.Services.AddTransient<SomeControl>();

        return builder.Build();
    }
}