using MeuLembrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembrete.CalculadoraStrategy
{
	internal class AvaliadorMensal : TemplateAvaliadorStrategy
	{
		protected override TipoIntervalo IntervaloAvaliado => TipoIntervalo.Mensal;

		protected override bool AvaliarCondicao(DateTime dataReferencia, Alerta item)
		{
			return dataReferencia.Day == item.Dia;
		}
	}
}
