﻿using MeuLembrete.Core.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MeuLembreteCore.Tests")]
namespace MeuLembrete.Core.CalculadoraStrategy
{
    internal class AvaliadorFactory
    {
        internal static IAvaliadorAlerta Create(TipoIntervalo tipoIntervalo)
        {
            return tipoIntervalo switch
            {
                TipoIntervalo.NaoRepetir => new AvaliadorUnico(),
                TipoIntervalo.Diario => new AvaliadorDiario(),
                TipoIntervalo.Semanal => new AvaliadorSemanal(),
                TipoIntervalo.Mensal => new AvaliadorMensal(),
                TipoIntervalo.Meses => new AvaliadorIntervaloMeses(),
                TipoIntervalo.Anual => new AvaliadorAnual(),
                _ => throw new NotImplementedException("Não há implementação para o alerta configurado."),
            };
        }
    }
}