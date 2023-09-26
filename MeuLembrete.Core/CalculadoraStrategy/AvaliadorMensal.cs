using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorMensal : TemplateAvaliadorPadraoStrategy
	{
        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{
			return dataReferencia.Day == item.Dia;
		}
	}
}
