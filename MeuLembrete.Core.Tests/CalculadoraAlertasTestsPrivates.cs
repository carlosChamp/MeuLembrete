using MeuLembrete.Core.Services.Handlers;

namespace MeuLembreteCore.Tests
{
    public class CalculadoraAlertasTestsPrivates : CalculadoraAlertas
    {
        [Fact]
        public void CalculadoraAlertas_DeveRetornarAMesmaInstanciaEmVariasChamadas()
        {
            IAvaliadorAlerta avaliador1 = GetTipoAvaliador(TipoIntervalo.Diario);

            IAvaliadorAlerta avaliador2 = GetTipoAvaliador(TipoIntervalo.Diario);

            Assert.StrictEqual(avaliador2, avaliador1);

        }
    }

    public class CalculadoraAlertasTests
    {
        [Fact]
        public void CalculadoraAlertas_DeveRetornarLembretesDoDia()
        {
            ILembreteService lembreteService = new LembreteServiceMock();
            LembreteCachedRepository lembreteCachedRepository = new LembreteCachedRepository(lembreteService);

            lembreteCachedRepository.UpdateCache();
            CalculadoraAlertas calculadoraAlertas = new CalculadoraAlertas();
            IEnumerable<Lembrete> lembretes = calculadoraAlertas.RetornarLembretesNoHorario(lembreteCachedRepository.LembretesCache, DateTime.Now, false);

            
            //Assert.True(lembretes.All(l => l.Alertas.Any(a => a.)));
        }
    }

}