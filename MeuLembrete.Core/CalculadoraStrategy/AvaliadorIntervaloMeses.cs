using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorIntervaloMeses : TemplateAvaliadorStrategy
    {
        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
        {
            int quantidadeMeses = ((dataReferencia.Year - item.DataInicio.Year) * 12) + (dataReferencia.Month - item.DataInicio.Month);
            return quantidadeMeses % item.IntervalorMeses == 0 && dataReferencia.Day == item.Dia;
        }
    }
}