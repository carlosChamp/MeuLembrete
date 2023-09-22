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

}