using MeuLembrete.Core.Model;
using MeuLembrete.Core.Util;

namespace MeuLembrete.Core.Services.Handlers
{
    public class LembreteServiceMock : ILembreteService
    {

        static List<Lembrete> lembreteList = new List<Lembrete>()
                {
                    new Lembrete()
                    {
                        Id = new Guid("d2cadef8-e354-4e5b-877a-56e03d883810"),
                        Titulo = "Aniversário de Namoro",
                        Detalhe = "Melhor namorada do mundo.",
                        FoiNotificado = false,
                        Cor="#FFDD00",
                        Tag = "Namoro",
                        Alertas = new Alertas()
                        {
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)),
                                IntervaloRepeticao = TipoIntervalo.NaoRepetir,
                                Data = DateOnly.FromDateTime(DateTime.Now.AddDays(0)),
                                Horario = TimeOnly.FromDateTime(DateTime.Now.AddMinutes(1)),
                                UltimoAcionamento = null,
                                
                            },
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)),
                                IntervaloRepeticao = TipoIntervalo.Semanal,
                                DiaDaSemana = new DiaDaSemana[]{ DiaDaSemana.Quinta, DiaDaSemana.Sexta },
                                Horario = new TimeOnly(12, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                                
                            },
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)),
                                IntervaloRepeticao = TipoIntervalo.Mensal,
                                Dia = 28,
                                Horario = new TimeOnly(15, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                                
                            }
                        }
                    },
                    new Lembrete() {
                        Id =new Guid("2e5dfc98-307e-4448-a2c9-0b6afd0b5679"),
                        Titulo = "Dizer pra namorada que ela é maravilhosa",
                        Detalhe = "Melhor namorada do mundo.",
                        FoiNotificado = false,
                        Tag = "Elogio",
                        Cor="#00DDFF",
                        Alertas = new Alertas()
                        {
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)),
                                IntervaloRepeticao = TipoIntervalo.Meses,
                                Dia = 14,
                                IntervalorMeses = 2,
                                DataFim = DateOnly.FromDateTime(DateTime.Now.AddYears(1)),
                                Horario = new TimeOnly(15, 0),
                                UltimoAcionamento = DateTime.Now.AddDays(-7),
                            },
                            new Alerta()
                            {
                                DataInicio = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)),
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

        public Task<Lembrete> GetLembreteById(Guid id)
        {
            return Task.FromResult(lembreteList.First(l => l.Id == id));
        }

        public Task<List<Lembrete>> GetLembretes()
        {
            return Task.FromResult(lembreteList);
        }

        public Task AddLembrete(Lembrete lembrete)
        {
            if (lembrete.Id == Guid.Empty)
            {
                Guid novoId = Guid.NewGuid();
                lembrete.Id = novoId;
            }
            
            lembreteList.Add(lembrete);

            return Task.CompletedTask;
        }

        public Task UpdateLembrete(Lembrete lembrete)
        {
            int posicaoLembrete = lembreteList.FindIndex(l => l.Id == lembrete.Id);

            lembreteList[posicaoLembrete] = lembrete;

            return Task.CompletedTask;
        }

        public void Validate(Lembrete lembrete)
        {
            if (string.IsNullOrWhiteSpace(lembrete.Titulo))
                throw new LembreteValidationException("Título é obrigatório.");

            if (string.IsNullOrWhiteSpace(lembrete.Tag))
                throw new LembreteValidationException("Tag é obrigatório.");

            if (lembrete.Alertas?.Count == 0)
                throw new LembreteValidationException("Adicione pelo menos 1 alerta");
        }
    }
}