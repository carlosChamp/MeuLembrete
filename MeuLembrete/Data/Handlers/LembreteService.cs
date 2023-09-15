namespace MeuLembrete.Data.Handlers
{
    public class LembreteService : ILembreteService
    {
        public Task<List<Lembrete>> GetLembretes()
        {
            return Task.FromResult(
                new List<Lembrete>()
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
                                DataInicio= DateTime.Now,
                                IntervaloRepeticao = TipoIntervalo.NaoRepetir,
                                Data = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                                Horario = new TimeOnly(17, 20)

                            },
                            new Alerta()
                            {
                                DataInicio = DateTime.Now,
                                IntervaloRepeticao = TipoIntervalo.Semanal,
                                DiaDaSemana = DiaDaSemana.Sexta,
                                Horario = new TimeOnly(12, 0),
                            }
                        }
                    },
                    new Lembrete() {
                        Id = 2,
                        Titulo = "Dizer pra namorada que ela é maravilhosa",
                        Detalhe = "Melhor namorada do mundo.",
                        FoiNotificado = false,

                    }
                });
        }
    }
}