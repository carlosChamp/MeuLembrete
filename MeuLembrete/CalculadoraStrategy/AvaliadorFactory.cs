﻿using MeuLembrete.Model;
using MeuLembrete.Services;

namespace MeuLembrete.CalculadoraStrategy
{
    internal class AvaliadorFactory
    {
        internal static IAvaliadorAlerta Create(TipoIntervalo tipoIntervalo)
        {
            return tipoIntervalo switch
            {
                TipoIntervalo.NaoRepetir => new AvaliadorDiario(),
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