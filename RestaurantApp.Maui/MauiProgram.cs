using Microsoft.FluentUI.AspNetCore.Components;
using RestaurantApp.CrossCuting.DependenciesApp;
using RestaurantApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Maui.Utilities;
using Microsoft.Extensions.Configuration;

namespace RestaurantApp.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            })
            .Configuration.AddJsonFile("appsettings.json");
        ;

        // Verificação para saber qual servidor de banco de dados vai utilizar
        static bool IsAndroid() => DeviceInfo.Current.Platform == DevicePlatform.Android;

        if (IsAndroid())
        {
            var dbPath = PathDB.GetPath("lundiDb.db");
            builder.Services.AddInfrastructure(
                options => options.UseSqlite($"Data Source={dbPath}")
            );
        }
        else
        {
            
            var conexao = builder.Configuration.GetConnectionString("MySql");

            
            builder.Services.AddInfrastructure(options =>
            {
                options.UseMySql(conexao, new MySqlServerVersion(new Version(8, 0, 35)));
            });          
        }

        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddFluentUIComponents();

        // Garantir a criação do banco de dados
        EnsureDatabaseCreated(builder);

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void EnsureDatabaseCreated(MauiAppBuilder builder)
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        using var serviceScope = serviceProvider.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        dbContext?.Database.EnsureCreated();
    }

}
