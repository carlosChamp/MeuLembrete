using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.Services
{
    public interface INotificationService
    {
        public void ShowNotification(Lembrete lembrete);
    }
}
