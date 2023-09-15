namespace MeuLembrete.Data
{
    public class Alertas:List<Alerta>
    {
       

    }

    public class Alerta
    {
        public TipoIntervalo IntervaloRepeticao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateOnly Data { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public DiaDaSemana DiaDaSemana { get; set; }

        public int IntervalorMeses { get; set; }
        public TimeOnly Horario { get; set; }

    }
}