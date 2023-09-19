using MeuLembrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.Services
{
    public interface INotificationService
    {
        public void ShowNotification(Lembrete lembrete);
    }
}
