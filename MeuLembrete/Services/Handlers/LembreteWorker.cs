﻿using MeuLembrete.CalculadoraStrategy;
using MeuLembrete.Model;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MeuLembrete.Services.Handlers;

internal class LembreteWorker : ILembreteWorker
{

	static Timer timer;
	private readonly LembreteCachedRepository lembreteCache;
	private readonly INotificationService notificationService;

	private readonly CalculadoraAlertas calculadoraAlertas;

	public LembreteWorker(LembreteCachedRepository lembreteService, INotificationService notificationService, CalculadoraAlertas calculadoraAlertas)
	{
		this.lembreteCache = lembreteService;
		this.notificationService = notificationService;
		this.calculadoraAlertas = calculadoraAlertas;
	}

	public void Setup()
	{
		timer = new Timer()
		{
			Interval = GetInterval()
		};
		timer.Elapsed += TimerElapsed;
		timer.Elapsed += SetTimerToDefault;
	}

	public void Start()
	{
		if (!timer.Enabled)
			timer.Start();
	}

	public void Stop()
	{
		timer.Stop();
	}

	private void SetTimerToDefault(object? sender, ElapsedEventArgs e)
	{
		timer.Interval = 60000;
	}

	public void TimerElapsed(object? sender, ElapsedEventArgs e)
	{
		IEnumerable<Lembrete> lembretesNoHorario = calculadoraAlertas.RetornarLembretesNoHorario(lembreteCache.LembretesCache, DateTime.Now);
		if (lembretesNoHorario?.Count() == 0)
			return;

		var lembrete = lembretesNoHorario.First();

		notificationService.ShowNotification(lembrete);
	}

	static double GetInterval()
	{
		DateTime now = DateTime.Now;
		return ((60 - now.Second) * 1000 - now.Millisecond);
	}
}

