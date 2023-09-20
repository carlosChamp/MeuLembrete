using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    public class CalculadoraAlertas
    {

        static Dictionary<TipoIntervalo, IAvaliadorAlerta> tiposAlertasDisponiveis = new();

        static IAvaliadorAlerta GetTipoAvaliador(TipoIntervalo tipoIntervalo)
        {
            if (!tiposAlertasDisponiveis.ContainsKey(tipoIntervalo))
            {
                tiposAlertasDisponiveis[tipoIntervalo] = AvaliadorFactory.Create(tipoIntervalo);
            }

            return tiposAlertasDisponiveis[tipoIntervalo];
        }

        public IEnumerable<Lembrete> RetornarLembretesNoHorario(IEnumerable<Lembrete> listaLembretes, DateTime dataReferencia)
        {
            List<Lembrete> lembretesComAlertaDisparados = new();
            foreach (var lembrete in listaLembretes)
            {
                foreach (var alerta in lembrete.Alertas)
                {
                    if (GetTipoAvaliador(alerta.IntervaloRepeticao).Avaliar(alerta, dataReferencia))
                        lembretesComAlertaDisparados.Add(lembrete);
                }
            }
            return lembretesComAlertaDisparados;
        }
    }
}