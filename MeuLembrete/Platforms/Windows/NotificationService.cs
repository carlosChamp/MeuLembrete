using MeuLembrete.Core.Model;
using MeuLembrete.Core.Services;
using Microsoft.Toolkit.Uwp.Notifications;

namespace MeuLembrete.Notification;

public class NotificationService : INotificationService
{
    public NotificationService() { }

    public void ShowNotification(Lembrete lembrete)
    {

        var snoozeBtn = new ToastButton();
        
		new ToastContentBuilder()
            .AddText(lembrete.Titulo, hintStyle: AdaptiveTextStyle.Header)
            .AddText(lembrete.Detalhe, hintStyle: AdaptiveTextStyle.Body)
            .AddButton(snoozeBtn
                        .SetContent("Me lembre mais tarde.")
                        .AddArgument("lembreteId", lembrete.Id))
            .Show();
    }
}




