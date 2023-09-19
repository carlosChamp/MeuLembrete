using MeuLembrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.CalculadoraStrategy
{
	internal class AvaliadorSemanal : TemplateAvaliadorStrategy
	{
		protected override TipoIntervalo IntervaloAvaliado => TipoIntervalo.Semanal;

		protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{
			return item.DiaDaSemana.Contains((DiaDaSemana)(int)dataReferencia.DayOfWeek);
		}
	}
}
