using MeuLembrete.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.Core.CalculadoraStrategy
{
	internal class AvaliadorDiario : TemplateAvaliadorPadraoStrategy
    {
		protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{
			return true;
		}
	}
}
