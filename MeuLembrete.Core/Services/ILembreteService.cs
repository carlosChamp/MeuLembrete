using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.Services
{
    public interface ILembreteService
    {
        public Task<List<Lembrete>> GetLembretes();

        public Task<Lembrete> GetLembreteById(int id);

        public Task AddLembrete(Lembrete lembrete);

        public Task UpdateLembrete(Lembrete lembrete);

        
	}
}