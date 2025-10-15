using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
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
        builder.Services.AddHttpClient<IApiService, ApiService>()
                        .ConfigureHttpClient(client =>
                        {
                            client.Timeout = Timeout.InfiniteTimeSpan;
                            client.DefaultRequestVersion = HttpVersion.Version20;
                            client.DefaultRequestHeaders.ExpectContinue = false;
                            client.DefaultRequestHeaders.ConnectionClose = false;
                        })
                        .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
                        {
                            MaxConnectionsPerServer = 200, 
                            PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                            PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                            AutomaticDecompression = DecompressionMethods.None,
                            EnableMultipleHttp2Connections = true,
                            UseProxy = false,
                            UseCookies = false,
                            ConnectTimeout = TimeSpan.FromSeconds(10),
                            ResponseDrainTimeout = TimeSpan.FromSeconds(5)
                        });

        builder.Services.AddSingleton<IStoryManager, StoryManager>();

        builder.Services.AddTransient<ImportDialog>();
        builder.Services.AddTransient<RunDialog>();
        builder.Services.AddTransient<RunResultControl>();

        return builder.Build();
    }
}