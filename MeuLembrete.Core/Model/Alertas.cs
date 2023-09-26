namespace MeuLembrete.Core.Model
{
    public class Alertas : List<Alerta>
    {
    }

    public class Alerta
    {
        public TipoIntervalo IntervaloRepeticao { get; set; }

        public DateOnly Data { get; set; }

        public int Dia { get; set; }

        public int Mes { get; set; }

        public DiaDaSemana[] DiaDaSemana { get; set; } = Array.Empty<DiaDaSemana>();

        public int IntervalorMeses { get; set; }

        public TimeOnly Horario { get; set; }

        public DateTime? UltimoAcionamento { get; internal set; }

        public DateOnly? DataInicio { get; set; }

        public DateOnly? DataFim { get; set; } = DateOnly.MaxValue;
    }
}