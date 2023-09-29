using System.ComponentModel;

namespace MeuLembrete.Core.Model
{
    public enum TipoIntervalo
    {
        [Description("Não Repetir")]
        NaoRepetir, // dia, mes, horas
        [Description("Diario")]
        Diario, // Precisa apenas das horas
        [Description("Semanal")]
        Semanal, // Precisa do dia da semana e das horas
        [Description("Mensal")]
        Mensal, // Precisa do dia do mês e das horas
        [Description("Intervalo de Meses")]
        Meses, // Precisa do dia do mês, do número de meses do intervalo e horas
        [Description("Anual")]
        Anual, // Precisa do dia, mês e das horas
    }
}