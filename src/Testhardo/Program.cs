using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Testhardo.Services;

namespace Testhardo;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;
    public static JsonSerializerOptions DefaultJsonSerializerOptions { get; set; } = new JsonSerializerOptions
    {
        WriteIndented = true,
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true
    };

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
        builder.Services.AddHttpClient<ApiService>(httpClient => httpClient.Timeout = TimeSpan.FromSeconds(5));
        builder.Services.AddSingleton<IStoryManager, StoryManager>();
        builder.Services.AddSingleton<IApiService, ApiService>();

       builder.Services.AddTransient<RunDialog>();

        return builder.Build();
    }
}