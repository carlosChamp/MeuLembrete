using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorDiario : TemplateAvaliadorPadraoStrategy
    {
        protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
        {
            return true;
        }
    }
}
