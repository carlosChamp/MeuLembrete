using MeuLembrete.Core.Services;
using MeuLembrete.Core.Services.Handlers;
using MeuLembrete.Core.CalculadoraStrategy;

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
			builder.Services.AddSingleton<CalculadoraAlertas>();
            builder.Services.AddSingleton<LembreteWorker>();
            builder.Services.AddTransient<ILembreteService, LembreteServiceMock>();
            
            //LembreteWorker lembreteWorker = new LembreteWorker(builder.Services.)

            return builder.Build();
        }

    }
}