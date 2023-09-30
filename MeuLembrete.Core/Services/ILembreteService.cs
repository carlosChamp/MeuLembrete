using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.Services
{
    public interface ILembreteService
    {
        public Task<List<Lembrete>> GetLembretes();

        public Task<Lembrete> GetLembreteById(Guid id);

        public Task AddLembrete(Lembrete lembrete);

        public Task UpdateLembrete(Lembrete lembrete);

        public void Validate(Lembrete lembrete);

        public Task Remove(IEnumerable<Lembrete> lembretes);

    }
}