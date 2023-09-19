namespace MeuLembrete.Model
{
    public enum TipoIntervalo
    {
        NaoRepetir, // dia, mes, horas
        Diario, // Precisa apenas das horas
        Semanal, // Precisa do dia da semana e das horas
        Mensal, // Precisa do dia do mês e das horas
        Meses, // Precisa do dia do mês, do número de meses do intervalo e horas
        Anual, // Precisa do dia, mês e das horas
    }
}