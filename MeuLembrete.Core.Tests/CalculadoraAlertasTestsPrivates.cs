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
            DateOnly DataAtual = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            ILembreteService lembreteService = new LembreteServiceMock();


            Guid guidLembreteDoDia = Guid.NewGuid();

            lembreteService.AddLembrete(new Lembrete()
            {
                Id = guidLembreteDoDia,
                Titulo = "Teste lembrete do dia",
                Detalhe = "Lembrete deve ser retornado",
                Tag = "Teste",
                Alertas = new Alertas()
                {
                    new Alerta()
                    {
                        DataInicio = DataAtual,
                        Data = DataAtual,
                        Horario = horaAtual.AddHours(2),
                        DataFim = DataAtual.AddDays(2),
                        IntervaloRepeticao = TipoIntervalo.NaoRepetir,

                    }
                }
            });
            Guid guidLembreteForaDia = Guid.NewGuid();

            lembreteService.AddLembrete(new Lembrete()
            {
                Id = guidLembreteForaDia,
                Titulo = "Teste lembrete fora da data",
                Detalhe = "Lembrete deve ser retornado",
                Tag = "Teste",
                Alertas = new Alertas()
                {
                    new Alerta()
                    {
                        DataInicio = DataAtual.AddDays(2),
                        Data = DataAtual.AddDays(2),
                        Horario = horaAtual.AddHours(2),
                        DataFim = DataAtual.AddDays(4),
                        IntervaloRepeticao = TipoIntervalo.NaoRepetir,

                    }
                }
            });


            LembreteCachedRepository lembreteCachedRepository = new LembreteCachedRepository(lembreteService);

            lembreteCachedRepository.UpdateCache();
            CalculadoraAlertas calculadoraAlertas = new();
            IEnumerable<Lembrete> lembretes = calculadoraAlertas.RetornarLembretesNoHorario(lembreteCachedRepository.LembretesCache, DateTime.Now, false);


            Assert.Contains(guidLembreteDoDia, lembretes.Select(l => l.Id));
            Assert.DoesNotContain(guidLembreteForaDia, lembretes.Select(l => l.Id));
        }


        [Fact]
        public void CalculadoraAlertas_DeveRetornarLembretesNoHorario()
        {
            DateOnly DataAtual = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now).AddHours(2);
            ILembreteService lembreteService = new LembreteServiceMock();


            Guid guidLembreteDoDia = Guid.NewGuid();

            lembreteService.AddLembrete(new Lembrete()
            {
                Id = guidLembreteDoDia,
                Titulo = "Teste lembrete do dia",
                Detalhe = "Lembrete deve ser retornado",
                Tag = "Teste",
                Alertas = new Alertas()
                {
                    new Alerta()
                    {
                        DataInicio = DataAtual,
                        Data = DataAtual,
                        Horario = horaAtual,
                        DataFim = DataAtual.AddDays(2),
                        IntervaloRepeticao = TipoIntervalo.NaoRepetir,

                    }
                }
            });
            Guid guidLembreteForaDia = Guid.NewGuid();

            lembreteService.AddLembrete(new Lembrete()
            {
                Id = guidLembreteForaDia,
                Titulo = "Teste lembrete fora da data",
                Detalhe = "Lembrete deve ser retornado",
                Tag = "Teste",
                Alertas = new Alertas()
                {
                    new Alerta()
                    {
                        DataInicio = DataAtual,
                        Data = DataAtual,
                        Horario = horaAtual.AddHours(2),
                        DataFim = DataAtual.AddDays(2),
                        IntervaloRepeticao = TipoIntervalo.NaoRepetir,

                    }
                }
            });


            LembreteCachedRepository lembreteCachedRepository = new LembreteCachedRepository(lembreteService);

            lembreteCachedRepository.UpdateCache();
            CalculadoraAlertas calculadoraAlertas = new();
            IEnumerable<Lembrete> lembretes = calculadoraAlertas.RetornarLembretesNoHorario(lembreteCachedRepository.LembretesCache, DataAtual.ToDateTime(horaAtual));


            Assert.Contains(guidLembreteDoDia, lembretes.Select(l => l.Id));
            Assert.DoesNotContain(guidLembreteForaDia, lembretes.Select(l => l.Id));
        }
    }

}