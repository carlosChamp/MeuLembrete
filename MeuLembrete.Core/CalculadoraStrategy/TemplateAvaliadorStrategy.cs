using MeuLembrete.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal abstract class TemplateAvaliadorStrategy : IAvaliadorAlerta
    {
        public bool Avaliar(Alerta alerta, DateTime dataReferencia)
        {
            return  AvaliarCondicao(dataReferencia, alerta) && 
                alerta.Horario.Hour == dataReferencia.Hour && 
                alerta.Horario.Minute == dataReferencia.Minute &&
                dataReferencia >= alerta.DataInicio;
        }

        protected abstract bool AvaliarCondicao(DateTime dataReferencia, Alerta item);

    }
}
