namespace MeuLembrete.Core.Model
{
    public class Lembrete
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Detalhe { get; set; }

        public bool FoiNotificado { get; set; }

        public Alertas Alertas { get; set; } = new Alertas();

    }
}
