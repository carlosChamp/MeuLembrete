using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorIntervaloMeses : TemplateAvaliadorPadraoStrategy
    {
        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
        {
            int quantidadeMeses = ((dataReferencia.Year - item.DataInicio.Value.Year) * 12) + (dataReferencia.Month - item.DataInicio.Value.Month);
            return quantidadeMeses % item.IntervalorMeses == 0 && dataReferencia.Day == item.Dia;
        }
    }
}