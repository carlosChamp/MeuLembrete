using MeuLembrete.Model;

namespace MeuLembrete.CalculadoraStrategy
{
    internal class AvaliadorIntervaloMeses : TemplateAvaliadorStrategy
    {
        protected override TipoIntervalo IntervaloAvaliado => TipoIntervalo.Meses;

        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
        {
#if DEBUG
            return false;
#endif
            throw new NotImplementedException();
        }
    }
}