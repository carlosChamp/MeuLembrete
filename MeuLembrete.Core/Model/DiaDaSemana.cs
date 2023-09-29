using System.ComponentModel;

namespace MeuLembrete.Core.Model
{
    public enum DiaDaSemana
    {
        [Description("Dom")]
        Domingo,
        [Description("Seg")]
        Segunda,
        [Description("Ter")]
        Terca,
        [Description("Qua")]
        Quarta,
        [Description("Qui")]
        Quinta,
        [Description("Sex")]
        Sexta,
        [Description("Sab")]
        Sabado
    }
}