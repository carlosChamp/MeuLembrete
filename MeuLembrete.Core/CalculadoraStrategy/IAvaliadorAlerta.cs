using MeuLembrete.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.Core.CalculadoraStrategy
{
	public interface IAvaliadorAlerta
	{
		bool Avaliar(Alerta alerta, DateTime dataReferencia);
	}
}
