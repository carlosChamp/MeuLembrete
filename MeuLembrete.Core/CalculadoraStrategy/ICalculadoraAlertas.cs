using MeuLembrete.Core.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MeuLembreteCore.Tests")]
namespace MeuLembrete.Core.CalculadoraStrategy
{
    public class CalculadoraAlertas
    {

        static Dictionary<TipoIntervalo, IAvaliadorAlerta> tiposAlertasDisponiveis = new();

        private protected static IAvaliadorAlerta GetTipoAvaliador(TipoIntervalo tipoIntervalo)
        {
            if (!tiposAlertasDisponiveis.ContainsKey(tipoIntervalo))
            {
                tiposAlertasDisponiveis[tipoIntervalo] = AvaliadorFactory.Create(tipoIntervalo);
            }

            return tiposAlertasDisponiveis[tipoIntervalo];
        }

        public IEnumerable<Lembrete> RetornarLembretesNoHorario(IEnumerable<Lembrete> listaLembretes, DateTime dataReferencia, bool validarHorarioAlerta = true)
        {
            List<Lembrete> lembretesComAlertaDisparados = new();
            foreach (var lembrete in listaLembretes)
            {
                foreach (var alerta in lembrete.Alertas)
                {
                    if (GetTipoAvaliador(alerta.IntervaloRepeticao).Avaliar(alerta, dataReferencia, validarHorarioAlerta))
                        lembretesComAlertaDisparados.Add(lembrete);
                }
            }
            return lembretesComAlertaDisparados;
        }
    }
}