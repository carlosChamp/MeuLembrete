using MeuLembrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.CalculadoraStrategy
{
	internal class AvaliadorAnual : TemplateAvaliadorStrategy
	{
		protected override TipoIntervalo IntervaloAvaliado => TipoIntervalo.Anual;

		protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{
			return item.Dia == dataReferencia.Day && item.Mes == dataReferencia.Month;
		}
	}
}
