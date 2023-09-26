using MeuLembrete.Core.Model;

namespace MeuLembrete.Core.CalculadoraStrategy
{
    public interface IAvaliadorAlerta
	{
		bool Avaliar(Alerta alerta, DateTime dataReferencia, bool validarHorarioAcionamento = true);

    }
}
