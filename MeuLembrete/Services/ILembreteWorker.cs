using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MeuLembrete.Services
{
    internal interface ILembreteWorker
    {
        void Setup();

        void Start();

        void Stop();

        public void TimerElapsed(object? sender, ElapsedEventArgs e);
    }
}
