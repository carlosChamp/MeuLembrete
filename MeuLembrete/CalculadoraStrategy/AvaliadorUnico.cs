using MeuLembrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.CalculadoraStrategy
{
	internal class AvaliadorUnico : TemplateAvaliadorStrategy
	{
		protected override TipoIntervalo IntervaloAvaliado => throw new NotImplementedException();

		protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{

			return (DateOnly.FromDateTime(dataReferencia.Date) == item.Data);
		}
	}
}
