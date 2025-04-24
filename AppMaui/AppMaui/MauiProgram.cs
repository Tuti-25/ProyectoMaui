using Microsoft.Extensions.Logging;
using Demo.ApiClient2.IoC;
using AppMaui.Paginas;
using MauiView;

namespace AppMaui
{
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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
            builder.Services.AddDemoApiClientService(x => x.ApiBaseAddress = "http://192.168.100.92:5151");
            builder.Services.AddTransient<IngresarDatos>();
            builder.Services.AddTransient<App>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}