using MeuLembrete.Services;
using MeuLembrete.Services.Handlers;

using Microsoft.AspNetCore.Components.WebView.Maui;

namespace MeuLembrete
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
                });
#if WINDOWS
            builder.Services.AddSingleton<INotificationService, MeuLembrete.Notification.NotificationService>();
#endif

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

			builder.Services.AddSingleton<LembreteCachedRepository>();
            builder.Services.AddSingleton<CalculadoraStrategy.CalculadoraAlertas>();
			builder.Services.AddTransient<ILembreteService, LembreteServiceMock>();
            builder.Services.AddTransient<ILembreteWorker, LembreteWorker>();
            //builder.Services.AddTransient<I>


            return builder.Build();
        }

    }
}