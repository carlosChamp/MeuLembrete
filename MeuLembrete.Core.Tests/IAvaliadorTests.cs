using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MeuLembrete.Core")]
namespace MeuLembreteCore.Tests
{
    public partial class IAvaliadorTests
    {
        [Fact]
        public void IAvaliador_DeveValidarIntervalosAnuais()
        {
            DateTime dataAtual = DateTime.Now;

            Alerta alertaAnual = new()
            {
                DataInicio = DateOnly.FromDateTime(dataAtual),
                IntervaloRepeticao = TipoIntervalo.Anual,
                Dia = dataAtual.Day,
                Mes = dataAtual.Month,
                Horario = TimeOnly.FromDateTime(dataAtual),
            };

            IAvaliadorAlerta avaliadorAnual = AvaliadorFactory.Create(TipoIntervalo.Anual);
            Assert.True(avaliadorAnual.Avaliar(alertaAnual, dataAtual));
            Assert.True(avaliadorAnual.Avaliar(alertaAnual, dataAtual.AddYears(1)));
        }

        [Fact]
        public void IAvaliador_DeveValidarIntervalosMensais()
        {
            DateTime dataAtual = DateTime.Now;

            Alerta alertaMensal = new()
            {
                DataInicio = DateOnly.FromDateTime(dataAtual),
                IntervaloRepeticao = TipoIntervalo.Mensal,
                Dia = dataAtual.Day,
                Horario = TimeOnly.FromDateTime(dataAtual),
            };

            IAvaliadorAlerta avaliador = AvaliadorFactory.Create(alertaMensal.IntervaloRepeticao);
            Assert.True(avaliador.Avaliar(alertaMensal, dataAtual));
            Assert.True(avaliador.Avaliar(alertaMensal, dataAtual.AddMonths(1)));
        }

        [Fact]
        public void IAvaliador_DeveValidarSemRepeticao()
        {
            DateTime dataAtual = DateTime.Now;
            
            Alerta alertaSemRepeticao = new()
            {
                DataInicio = DateOnly.FromDateTime(dataAtual),
                IntervaloRepeticao = TipoIntervalo.NaoRepetir,
                Data = DateOnly.FromDateTime(dataAtual),
                Horario = TimeOnly.FromDateTime(dataAtual),
            };

            IAvaliadorAlerta avaliador = AvaliadorFactory.Create(alertaSemRepeticao.IntervaloRepeticao);
            Assert.True(avaliador.Avaliar(alertaSemRepeticao, dataAtual));
            Assert.False(avaliador.Avaliar(alertaSemRepeticao, dataAtual.AddDays(1)));
        }

        [Fact]
        public void IAvaliador_DeveValidarSemanal()
        {
            DateTime dataAtual = DateTime.Now;

            Alerta alertaSemanal = new()
            {
                DataInicio = DateOnly.FromDateTime(dataAtual),
                IntervaloRepeticao = TipoIntervalo.Semanal,
                DiaDaSemana = new DiaDaSemana[] { (DiaDaSemana)(int)dataAtual.DayOfWeek },
                Horario = TimeOnly.FromDateTime(dataAtual),
            };

            IAvaliadorAlerta avaliador = AvaliadorFactory.Create(alertaSemanal.IntervaloRepeticao);
            Assert.True(avaliador.Avaliar(alertaSemanal, dataAtual));
            Assert.True(avaliador.Avaliar(alertaSemanal, dataAtual.AddDays(7)));
            Assert.False(avaliador.Avaliar(alertaSemanal, dataAtual.AddDays(6)));
        }

        [Fact]
        public void IAvaliador_DeveValidarIntervalosDiario()
        {
            DateTime dataAtual = DateTime.Now;

            Alerta alertaDiario = new()
            {
                DataInicio = DateOnly.FromDateTime(dataAtual),
                IntervaloRepeticao = TipoIntervalo.Diario,
                Horario = TimeOnly.FromDateTime(dataAtual),
            };

            IAvaliadorAlerta avaliador = AvaliadorFactory.Create(alertaDiario.IntervaloRepeticao);
            Assert.True(avaliador.Avaliar(alertaDiario, dataAtual));
            Assert.True(avaliador.Avaliar(alertaDiario, dataAtual.AddDays(1)));
            Assert.True(avaliador.Avaliar(alertaDiario, dataAtual.AddDays(2)));
            Assert.True(avaliador.Avaliar(alertaDiario, dataAtual.AddMonths(2)));
        }

        [Fact]
        public void IAvaliador_DeveValidarIntervalosMeses()
        {
            DateTime dataAtual = DateTime.Now;
            
            Alerta alertaMeses = new()
            {
                DataInicio = DateOnly.FromDateTime(dataAtual),
                IntervaloRepeticao = TipoIntervalo.Meses,
                IntervalorMeses = 13,
                Dia = dataAtual.Day,
                Horario = TimeOnly.FromDateTime(dataAtual),
            };

            IAvaliadorAlerta avaliador = AvaliadorFactory.Create(alertaMeses.IntervaloRepeticao);
            Assert.True(avaliador.Avaliar(alertaMeses, dataAtual));
            Assert.False(avaliador.Avaliar(alertaMeses, dataAtual.AddMonths(12)));
            Assert.True(avaliador.Avaliar(alertaMeses, dataAtual.AddMonths(13)));
            Assert.False(avaliador.Avaliar(alertaMeses, dataAtual.AddMonths(24)));
            Assert.True(avaliador.Avaliar(alertaMeses, dataAtual.AddMonths(26)));
        }

        [Fact]
        public void IAvaliador_DeveValidarIntervalosMesesQuandoDiaAlertaMenorQueDataInicio()
        {
            DateTime dataAtual = new(2023, 9, 20, 15, 0, 0);
            DateTime dataNotificacao = new(2023, 9, 15, 15, 0, 0);

            Alerta alertaMeses = new()
            {
                DataInicio = DateOnly.FromDateTime(dataAtual),
                IntervaloRepeticao = TipoIntervalo.Meses,
                IntervalorMeses = 13,
                Dia = 15,
                Horario = TimeOnly.FromDateTime(dataAtual),
            };

            IAvaliadorAlerta avaliador = AvaliadorFactory.Create(alertaMeses.IntervaloRepeticao);
            Assert.False(avaliador.Avaliar(alertaMeses, dataAtual));
            Assert.False(avaliador.Avaliar(alertaMeses, dataNotificacao.AddMonths(12)));
            Assert.True(avaliador.Avaliar(alertaMeses, dataNotificacao.AddMonths(13)));
            Assert.False(avaliador.Avaliar(alertaMeses, dataNotificacao.AddMonths(24)));
            Assert.True(avaliador.Avaliar(alertaMeses, dataNotificacao.AddMonths(26)));
        }
    }
}