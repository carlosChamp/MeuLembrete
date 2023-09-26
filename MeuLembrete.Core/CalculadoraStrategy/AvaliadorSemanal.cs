using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorSemanal : TemplateAvaliadorPadraoStrategy
    {
        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{
			return item.DiaDaSemana.Contains((DiaDaSemana)(int)dataReferencia.DayOfWeek);
		}
	}
}

