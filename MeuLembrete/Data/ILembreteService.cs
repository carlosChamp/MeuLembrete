namespace MeuLembrete.Data
{
    public interface ILembreteService
    {
        public Task<List<Lembrete>> GetLembretes();
    }
}