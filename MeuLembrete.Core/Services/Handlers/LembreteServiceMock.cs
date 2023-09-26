using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.Services.Handlers
{
    public class LembreteServiceMock : ILembreteService
    {

        List<Lembrete> lembreteList = new List<Lembrete>()
                {
                    new Lembrete()
                    {
                        Id = Guid.NewGuid(),
                        Titulo = "Aniversário de Namoro",
                        Detalhe = "Melhor namorada do mundo.",
                        FoiNotificado = false,
                        Tag = "Namoro",
                        Alertas = new Alertas()
                        {
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now),
                                IntervaloRepeticao = TipoIntervalo.NaoRepetir,
                                Data = DateOnly.FromDateTime(DateTime.Now.AddDays(0)),
                                Horario = TimeOnly.FromDateTime(DateTime.Now.AddMinutes(1)),
                                UltimoAcionamento = null,
                                
                            },
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now),
                                IntervaloRepeticao = TipoIntervalo.Semanal,
                                DiaDaSemana = new DiaDaSemana[]{ DiaDaSemana.Quinta, DiaDaSemana.Sexta },
                                Horario = new TimeOnly(12, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                                
                            },
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now),
                                IntervaloRepeticao = TipoIntervalo.Mensal,
                                Dia = 28,
                                Horario = new TimeOnly(15, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                                
                            }
                        }
                    },
                    new Lembrete() {
                        Id = Guid.NewGuid(),
                        Titulo = "Dizer pra namorada que ela é maravilhosa",
                        Detalhe = "Melhor namorada do mundo.",
                        FoiNotificado = false,
                        Tag = "Elogio",
                        Alertas = new Alertas()
                        {
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now),
                                IntervaloRepeticao = TipoIntervalo.Meses,
                                Dia = 14,
                                IntervalorMeses = 2,
                                DataFim = DateOnly.FromDateTime(DateTime.Now.AddYears(1)),
                                Horario = new TimeOnly(15, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                            },
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now),
                                IntervaloRepeticao = TipoIntervalo.Anual,
                                Dia = 14,
                                Mes = 2,
                                DataFim = DateOnly.FromDateTime(DateTime.Now.AddYears(2)),
                                Horario = new TimeOnly(15, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                            },
                        }
                    }
                };


        public LembreteServiceMock() { }

        public Task<Lembrete> GetLembreteById(int id)
        {
            return Task.FromResult(lembreteList.First(l => l.Id == Guid.NewGuid()));
        }

        public Task<List<Lembrete>> GetLembretes()
        {
            return Task.FromResult(lembreteList);
        }

        public Task AddLembrete(Lembrete lembrete)
        {
            Guid novoId = Guid.NewGuid();

            lembrete.Id = novoId;
            lembreteList.Add(lembrete);

            return Task.CompletedTask;
        }

        public Task UpdateLembrete(Lembrete lembrete)
        {
            int posicaoLembrete = lembreteList.FindIndex(l => l.Id == lembrete.Id);

            lembreteList[posicaoLembrete] = lembrete;

            return Task.CompletedTask;
        }
    }
}