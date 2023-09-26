using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorUnico : TemplateAvaliadorPadraoStrategy
	{
        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{
			return (DateOnly.FromDateTime(dataReferencia.Date) == item.Data);
		}
	}
}
