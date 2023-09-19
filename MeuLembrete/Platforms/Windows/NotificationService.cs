using MeuLembrete.Model;
using MeuLembrete.Services;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.Notification;

public class NotificationService : INotificationService
{
    public NotificationService() { }

    public void ShowNotification(Lembrete lembrete)
    {
        new ToastContentBuilder()
            //.AddToastActivationInfo(null, ToastActivationType.Foreground)
            .AddText(lembrete.Titulo, hintStyle: AdaptiveTextStyle.Header)
            .AddText(lembrete.Detalhe, hintStyle: AdaptiveTextStyle.Body)
            .AddButton(new ToastButtonSnooze())
            .Show();
    }
}




