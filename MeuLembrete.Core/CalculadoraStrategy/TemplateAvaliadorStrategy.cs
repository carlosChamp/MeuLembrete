using MeuLembrete.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal abstract class TemplateAvaliadorPadraoStrategy : IAvaliadorAlerta
    {
        public bool Avaliar(Alerta alerta, DateTime dataReferencia)
        {
            return  AvaliarCondicao(dataReferencia, alerta) &&
                ValidarHorarioAcionamento(dataReferencia, alerta) &&
                ValidarLimitesDataInicioEFim(dataReferencia, alerta);
        }

        protected bool ValidarHorarioAcionamento(DateTime dataReferencia, Alerta alerta)
        {
            return alerta.Horario.Hour == dataReferencia.Hour && alerta.Horario.Minute == dataReferencia.Minute;
        }

        protected bool ValidarLimitesDataInicioEFim(DateTime dataReferencia, Alerta alerta)
        {
            DateOnly dataFinal = alerta.DataFim ?? DateOnly.MaxValue;

            return DateOnly.FromDateTime(dataReferencia) >= alerta.DataInicio && 
                   DateOnly.FromDateTime(dataReferencia) <= dataFinal;
        }

        protected abstract bool AvaliarCondicao(DateTime dataReferencia, Alerta item);

    }
}
