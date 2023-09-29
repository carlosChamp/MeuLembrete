namespace MeuLembrete.Core.Model
{
    public class Lembrete
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Detalhe { get; set; }

        public string Tag { get; set; }

        public string Cor { get; set; }

        public bool FoiNotificado { get; set; } 

        public Alertas Alertas { get; set; } = new Alertas();

    }
}
