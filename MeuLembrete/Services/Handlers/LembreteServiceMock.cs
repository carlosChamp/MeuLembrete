using MeuLembrete.Model;

namespace MeuLembrete.Services.Handlers
{
    public class LembreteServiceMock : ILembreteService
    {

        List<Lembrete> lembreteList = new List<Lembrete>()
                {
                    new Lembrete()
                    {
                        Id = 1,
                        Titulo = "Aniversário de Namoro",
                        Detalhe = "Melhor namorada do mundo.",
                        FoiNotificado = false,
                        Alertas = new Alertas()
                        {
                            new Alerta()
                            {
                                DataInicio = DateTime.Now,
                                IntervaloRepeticao = TipoIntervalo.NaoRepetir,
                                Data = DateOnly.FromDateTime(DateTime.Now.AddDays(0)),
                                Horario = TimeOnly.FromDateTime(DateTime.Now.AddMinutes(1)),
                                UltimoAcionamento = null,
                                ProximoAcionamento = null
                            },
                            new Alerta()
                            {
                                DataInicio = DateTime.Now,
                                IntervaloRepeticao = TipoIntervalo.Semanal,
                                DiaDaSemana = new DiaDaSemana[]{ DiaDaSemana.Quinta, DiaDaSemana.Sexta },
                                Horario = new TimeOnly(12, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                                ProximoAcionamento = DateTime.Now
                            },
                            new Alerta()
                            {
                                DataInicio = DateTime.Now,
                                IntervaloRepeticao = TipoIntervalo.Mensal,
                                Dia = 28,
                                Horario = new TimeOnly(15, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                                ProximoAcionamento = DateTime.Now
                            }
                        }
                    },
                    new Lembrete() {
                        Id = 2,
                        Titulo = "Dizer pra namorada que ela é maravilhosa",
                        Detalhe = "Melhor namorada do mundo.",
                        FoiNotificado = false,

                    }
                };


        public LembreteServiceMock() { }

        public Task<Lembrete> GetLembreteById(int id)
        {
            return Task.FromResult(lembreteList.First(l => l.Id == id));
        }

        public Task<List<Lembrete>> GetLembretes()
        {
            return Task.FromResult(lembreteList);
        }

        public Task AddLembrete(Lembrete lembrete)
        {
            int novoId = lembreteList.Max(l => l.Id) + 1;

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