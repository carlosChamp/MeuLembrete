using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorIntervaloMeses : TemplateAvaliadorStrategy
    {
        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
        {
#if DEBUG
            return false;
#endif
            throw new NotImplementedException();
        }
    }
}