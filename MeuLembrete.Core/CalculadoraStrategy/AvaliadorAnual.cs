using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorAnual : TemplateAvaliadorPadraoStrategy
	{     
        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{
			return item.Dia == dataReferencia.Day && item.Mes == dataReferencia.Month;
		}
	}
}
