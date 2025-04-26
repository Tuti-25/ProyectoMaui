using Microsoft.Extensions.Logging;
using Demo.ApiClient2.IoC;
using AppMaui.Paginas;
using MauiView;
using Demo.ApiClient2.Models.ApiModels;
using CommunityToolkit.Maui;

namespace AppMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
            builder.Services.AddDemoApiClientService(x => x.ApiBaseAddress = "http://192.168.18.75:5151");
            builder.Services.AddTransient<LoginOrSignUp>();
            builder.Services.AddTransient<SignUp>();
            builder.Services.AddTransient<App>();
            builder.Services.AddSingleton<Usuario>();
            builder.Services.AddSingleton<Login>();
            builder.Services.AddTransient<Casos>();
            builder.Services.AddTransient<CrearCaso>();


#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}